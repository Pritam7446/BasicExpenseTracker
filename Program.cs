using BasicExpenseTracker.Data;
using Microsoft.EntityFrameworkCore;
using BasicExpenseTracker.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Add connection string and DbContext configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Expenses}/{action=Index}/{id?}"); // Changed default to Expenses Controller

app.Run();