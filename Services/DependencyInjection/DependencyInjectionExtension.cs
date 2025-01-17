using System.Reflection;

namespace TravelManagement.Services.DependencyInjection
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddServicesByInterface(this IServiceCollection services, Assembly assembly, string interfaceName)
        {
            var types = assembly.GetTypes();

            foreach (var type in types)
            {
                var interfaceType = type.GetInterfaces().FirstOrDefault(x => x.Name == interfaceName);
                if (interfaceType != null)
                    services.AddScoped(type);
            }

            return services;
        }
    }
}
