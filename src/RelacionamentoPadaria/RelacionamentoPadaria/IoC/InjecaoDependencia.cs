using RelacionamentoPadaria.Data.Repository;
using RelacionamentoPadaria.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace RelacionamentoPadaria.IoC
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection AdicionarIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options => options.UseMySql(configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(7, 4, 30))));

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IContatosRepository, ContatosRepository>();
            services.AddScoped<IDashboardRepository, DashboardRepository>();

            return services;
        }
    }
}