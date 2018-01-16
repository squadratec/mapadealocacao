using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SQH.Business.Contract;
using SQH.Business.Service;
using SQH.DataAccess.Contract;
using SQH.DataAccess.Service;
using SQH.Entities.Database;
using System.Reflection;
using System.Linq;

namespace SQH.IoC
{
    public class Injector
    {
        public static void RegisterIoC(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSingleton<IDatabaseConfig, DatabaseConfig>(serviceProvider =>
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                return new DatabaseConfig(connectionString);
            });

            var types = Assembly.GetExecutingAssembly().GetReferencedAssemblies()
                        .Select(Assembly.Load)
                        .SelectMany(x => x.DefinedTypes)
                        .Where(x => x.IsInterface && 
                                    x.FullName.StartsWith("SQH") && 
                                    (x.Name.EndsWith("Repository") || x.Name.EndsWith("Service")));

            foreach (var interfaceType in types.Where(t => t.IsInterface))
            {
                var concreteType = Assembly
                        .GetExecutingAssembly()
                        .GetReferencedAssemblies()
                        .Select(Assembly.Load)
                        .SelectMany(x => x.DefinedTypes)
                        .FirstOrDefault(thisType => !thisType.IsInterface && interfaceType.IsAssignableFrom(thisType));

                if (concreteType != null)
                    services.AddSingleton(interfaceType, concreteType);
            }
        }
    }
}