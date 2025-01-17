using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using TravelManagement.Database;
using TravelManagement.Models.Shared.Repository;
using TravelManagement.Services.Authentication;
using TravelManagement.Services.DependencyInjection;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var jwtSection = builder.Configuration.GetSection("JWT");
        builder.Services.Configure<JWTSettings>(jwtSection);

        var jwtSettings = jwtSection.Get<JWTSettings>();

        AuthenticationHelper.Configure(jwtSettings);

        var key = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        //Insere o token em todas as requisições
                        if (context.Request.Cookies.ContainsKey(AuthenticationConsts.CookieAuthName))
                        {
                            context.Token = context.Request.Cookies[AuthenticationConsts.CookieAuthName];
                        }

                        return Task.CompletedTask;
                    }
                };

            });

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
            pattern: "{controller=Authentication}/{action=Index}");

        app.Run();
    }
}