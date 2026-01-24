using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Text.Json;
using VN_Travel_.DAL;
using VN_Travel_.DAL.Entities;
using System.Reflection;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace VN_Travel_.Controllers
{
    [Route("api/{entity}")]
    [ApiController]
    public class TestApiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public TestApiController(ApplicationDbContext db)
        {
            _db = db;
        }

        private Type? ResolveEntityType(string entity)
        {
            return entity?.ToLowerInvariant() switch
            {
                "customers" => typeof(Customer),
                "orders" => Type.GetType("VN_Travel_.DAL.Entities.Order, VN_Travel_.DAL"),
                "tours" => Type.GetType("VN_Travel_.DAL.Entities.Tour, VN_Travel_.DAL"),
                "reviews" => Type.GetType("VN_Travel_.DAL.Entities.Review, VN_Travel_.DAL"),
                "hotels" => typeof(Hotel),
                "countries" => typeof(Country),
                _ => null
            };
        }

        [HttpGet]
        public IActionResult GetList(string entity)
        {
            var type = ResolveEntityType(entity);
            if (type == null) return NotFound($"Unknown entity '{entity}'.");

            // Use reflection to call the generic DbContext.Set<TEntity>() with the runtime Type
            var setMethod = typeof(DbContext)
                .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(m => m.Name == "Set" && m.IsGenericMethodDefinition && m.GetParameters().Length == 0);

            if (setMethod == null) return BadRequest("Unable to locate DbContext.Set method.");

            var genericSet = setMethod.MakeGenericMethod(type);
            var dbSet = genericSet.Invoke(_db, null);
            if (dbSet == null) return Ok(new System.Collections.Generic.List<object>());

            var resultList = new System.Collections.Generic.List<object>();
            foreach (var item in (IEnumerable)dbSet) resultList.Add(item);
            return Ok(resultList);
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(string entity, string id)
        {
            var type = ResolveEntityType(entity);
            if (type == null) return NotFound($"Unknown entity '{entity}'.");

            object idValue = id;
            // try parse as int
            if (int.TryParse(id, out var intId)) idValue = intId;

            // Use non-generic DbContext.Find(Type, params object[] keyValues)
            var found = _db.Find(type, idValue);
            if (found == null) return NotFound();
            return Ok(found);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string entity)
        {
            var type = ResolveEntityType(entity);
            if (type == null) return NotFound($"Unknown entity '{entity}'.");

            using var sr = new StreamReader(Request.Body);
            var body = await sr.ReadToEndAsync();
            if (string.IsNullOrWhiteSpace(body)) return BadRequest("Empty request body.");

            object? instance;
            try
            {
                instance = JsonSerializer.Deserialize(body, type, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                return BadRequest($"Invalid JSON: {ex.Message}");
            }

            if (instance == null) return BadRequest("Unable to deserialize payload.");

            // Use non-generic DbContext.Add(object)
            _db.Add(instance);
            await _db.SaveChangesAsync();

            // try to get Id property for CreatedAt location header
            var idProp = type.GetProperty("Id");
            var idVal = idProp?.GetValue(instance)?.ToString();

            return CreatedAtAction(nameof(GetOne), new { entity = entity, id = idVal }, instance);
        }
    }
}