using TravelManagement.Database;
using Microsoft.EntityFrameworkCore;
using TravelManagement.Models.Shared.Repository;
using TravelManagement.Models.Shared.Service;
using TravelManagement.Models.Shared.Actions;
using System.Reflection;
using TravelManagement.DependencyInjection;
using TravelManagement.Models.Driver.Service;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<TravelManagementDbContext>(options =>
            options.UseMySql(
                builder.Configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 40)))
        );

        builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

        builder.Services.AddServicesByInterface(Assembly.GetExecutingAssembly(), "IActionBase");
        builder.Services.AddServicesByInterface(Assembly.GetExecutingAssembly(), "IServiceBase");

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Driver}/{action=Index}");

        app.Run();
    }
}