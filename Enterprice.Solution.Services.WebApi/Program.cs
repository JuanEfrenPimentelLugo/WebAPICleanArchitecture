using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Enterprice.Solution.Application.UseCases;
using Enterprice.Solution.Persistence;
using Enterprice.Solution.Services.WebApi.Modules.Authentication;
using Enterprice.Solution.Services.WebApi.Modules.Feature;
using Enterprice.Solution.Services.WebApi.Modules.Injection;
using Enterprice.Solution.Services.WebApi.Modules.Redis;
using Enterprice.Solution.Services.WebApi.Modules.Swagger;
using Enterprice.Solution.Services.WebApi.Modules.Versioning;
using Asp.Versioning.ApiExplorer;
using Enterprice.Solution.Services.WebApi.Modules.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddFeature(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInjection(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddVersioning();
builder.Services.AddSwagger();
builder.Services.AddRedisCache(builder.Configuration);

var app = builder.Build();

// configure the Http request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // build a swagger endpoint for each discovered API version
        
        foreach (var description in provider.ApiVersionDescriptions)
        {
            c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });

    app.UseReDoc(options =>
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.DocumentTitle = "Enterprice Technology Services API";
            options.SpecUrl = $"/swagger/{description.GroupName}/swagger.json";
        }
    });
}


app.UseHttpsRedirection();
app.UseCors("policyApiEcommerce");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.AddMiddleware();

app.Run();

public partial class Program { };