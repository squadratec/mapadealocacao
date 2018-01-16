using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SQH.DataAccess.Contract;
using System.Linq;
using System.Reflection;

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


            services.AddSingleton<IProjetoRepository, ProjetoRepository>();
            services.AddSingleton<IProjetoService, ProjetoService>();

            services.AddSingleton<ISharepointRepository, SharepointRepository>();
            services.AddSingleton<ISharepointService, SharepointService>();

            services.AddSingleton<IRecursoRepository, RecursoRepository>();
            services.AddSingleton<IRecursoService, RecursoService>();

            services.AddSingleton<ITipoAlocacaoRepository, TipoAlocacaoRepository>();
            services.AddSingleton<ITipoAlocacaoService, TipoAlocacaoService>();
            //var types = Assembly.GetExecutingAssembly().GetReferencedAssemblies()
            //            .Select(Assembly.Load)
            //            .SelectMany(x => x.DefinedTypes)
            //            .Where(x => x.IsInterface && 
            //                        x.FullName.StartsWith("SQH") && 
            //                        (x.Name.EndsWith("Repository") || x.Name.EndsWith("Service")));

            //foreach (var interfaceType in types.Where(t => t.IsInterface))
            //{
            //    var concreteType = Assembly
            //            .GetExecutingAssembly()
            //            .GetReferencedAssemblies()
            //            .Select(Assembly.Load)
            //            .SelectMany(x => x.DefinedTypes)
            //            .FirstOrDefault(thisType => !thisType.IsInterface && interfaceType.IsAssignableFrom(thisType));

            //    if (concreteType != null)
            //        services.AddSingleton(interfaceType, concreteType);
            //}
        }
    }
}