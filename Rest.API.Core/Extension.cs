using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Rest.API.Core
{
    public static class EndpointExtension
    {
        public static void AddEndpoint(this IServiceCollection service, params Type[] types)
        {
            var endpoints = new List<IEndpoint>();

            foreach (var type in types)
            {
                endpoints.AddRange(type.Assembly.ExportedTypes
                                                .Where(x => typeof(IEndpoint).IsAssignableFrom(x)
                                                            && !x.IsInterface
                                                            && !x.IsAbstract)
                                                .Select(Activator.CreateInstance)
                                                .Cast<IEndpoint>());
            }

            service.AddSingleton(endpoints as IReadOnlyCollection<IEndpoint>);
        }

        public static void UseEndpoint(this WebApplication app)
        {
            var endpoints = app.Services.GetRequiredService<IReadOnlyCollection<IEndpoint>>();

            foreach (var endpoint in endpoints)
            {
                endpoint.ConfigureApplication(app);
            }
        }
    }

    public static class SwaggerExtension
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("dev", new OpenApiInfo
                {
                    Title = "Sample Web API Core",
                    Version = $"DEV-{Environment.Version.Major}.{Environment.Version.Minor}.{DateTime.Now:yyyyMMddHHmmss}",
                    Description = "Sample Web API"
                });

                string xmlDocFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlDocPath = Path.Combine(AppContext.BaseDirectory, xmlDocFile);
                c.IncludeXmlComments(xmlDocPath);
            });
        }

        public static void UseSwaggerApp(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(x =>
                {
                    x.SwaggerEndpoint("/swagger/dev/swagger.json", "Rest.API.Core");
                    x.RoutePrefix = "swagger";
                    x.DocumentTitle = "Sample Web API";
                });
            }
        }
    }

    public static class CORSExtension
    {
        public static void ConfigureCORS(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                //NOT FOR PRODUCTION
                options.AddPolicy("AllowAnyOrigin", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });
        }
    }
}
