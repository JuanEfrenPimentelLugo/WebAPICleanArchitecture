using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Enterprice.Solution.Services.WebApi.Modules.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigureSwaggerOptions"/> class.
        /// </summary>
        /// <param name="provider">The <see cref="IApiVersionDescriptionProvider">provider</see> used to generate Swagger documents.</param>
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

        /// <inheritdoc />
        public void Configure(SwaggerGenOptions options)
        {
            // add a swagger document for each discovered API version
            // note: you might choose to skip or document deprecated API versions differently
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description) {
            var info = new OpenApiInfo
            {
                Version = description.ApiVersion.ToString(),
                Title = "Enterprice Technology Services API",
                Description = "A simple example ASP.NET Core Web API. ",
                TermsOfService = new Uri("https://www.jie.mx/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Development",
                    Email = "jpimentel@jie.mx",
                    Url = new Uri("https://www.jie.mx/contact")
                },
                License = new OpenApiLicense
                {
                    Name = "Use under ...",
                    Url = new Uri("https://www.jie.mx/licence")
                }
            };

            if (description.IsDeprecated)
            {
                info.Description += "Esta versión de la API ha quedado obsoleta.";
            }

            return info;
        }
    }
}
