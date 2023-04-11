namespace IGotUScraperApi.DependencyInjection
{
    public static class DependencyResolver
    {
        public static void AddDependencyResolver(this IServiceCollection services)
        {
            RegisterCommonTypes(services);
            RegisterRepositories(services);
        }

        private static void RegisterCommonTypes(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
        }
    }

}
