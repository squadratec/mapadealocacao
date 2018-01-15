using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SQH.Business.Contract;
using SQH.Business.Service;
using SQH.DataAccess.Contract;
using SQH.DataAccess.Service;
using SQH.Entities.Database;

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

            services.AddSingleton<IRecursoRepository, RecursoRepository>();
            services.AddSingleton<IRecursoService, RecursoService>();

            services.AddSingleton<ITipoAlocacaoRepository, TipoAlocacaoRepository>();
            services.AddSingleton<ITipoAlocacaoService, TipoAlocacaoService>();
        }

    }
}
