using AserAgence.Repositories.Implementations;
using AserAgence.Repositories.Interfaces;
using AserAgence.Repositories;

namespace AserAgence.Configurations
{
    public static class RepositoryRegistration
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IVillageRepository, VillageRepository>();
            services.AddScoped<ICommuneRepository, CommuneRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<ISurveyRepository, SurveyRepository>();

        }
    }
}
