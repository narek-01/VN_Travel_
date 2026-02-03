using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VN_Travel_.DAL;
using VN_Travel_.DAL.Entities;

namespace VN_Travel_.Pages.Tours
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public List<Tour> Tours { get; set; } = new();

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Tours = await _context.Tours
                .Include(t => t.Hotel)
                .ToListAsync();
        }
    }
}