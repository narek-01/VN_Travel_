using VN_Travel_.DAL;
using VN_Travel_.DAL.Interface;
using VN_Travel_.DAL.Repositories;
using VN_Travel_.Service.Interface;
using VN_Travel_.Service.Services;

var builder = VN_Travel_.CreateBuilder(args);   

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddTransient<ICountryRepository, CountryRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<ITourRepository, TourRepository>();
builder.Services.AddTransient<IReviewRepository, ReviewRepository>();
builder.Services.AddTransient<IHotelRepository, HotelRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<ICountryService, CountryService>();
builder.Services.AddTransient<ITourService, TourService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IHotelService,HotelService >();
builder.Services.AddTransient<IReviewService,ReviewService >();
builder.Services.AddTransient<IOrderService, OrderService >();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// Serve static files from wwwroot early (css, images, js)
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages();

app.Run();