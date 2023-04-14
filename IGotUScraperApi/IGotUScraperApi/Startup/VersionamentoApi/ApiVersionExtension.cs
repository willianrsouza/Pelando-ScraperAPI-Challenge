using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace IGotUScraperApi.Startup.VersionamentoApi
{
    [ExcludeFromCodeCoverage]
    public static class ApiVersionExtension
    {
        public static void ConfigureApiVersion(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }
    }
}
