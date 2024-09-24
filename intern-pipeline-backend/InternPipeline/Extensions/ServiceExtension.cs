using InternPipeline.Managers.Interface;
using InternPipeline.Managers.Manager;
using InternPipeline.Repositories.Interface;
using InternPipeline.Repositories.Repository;

namespace InternPipeline.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection APIModuleServices(this IServiceCollection services)
        {
            try
            {
                // DI here
                services.AddScoped<ITopicManager, TopicManager>();
                services.AddScoped<ITopicRepository, TopicRepository>();
                services.AddScoped<IBlogManager, BlogManager>();
                services.AddScoped<IBlogRepository, BlogRepository>();

                return services;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
