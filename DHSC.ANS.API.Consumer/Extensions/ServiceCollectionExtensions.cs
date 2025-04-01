using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using DHSC.ANS.API.Consumer.DTOs;
using DHSC.ANS.API.Consumer.Validators;
using DHSC.ANS.API.Consumer.Interfaces;
using DHSC.ANS.API.Consumer.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.Extensions.Options;
using DHSC.ANS.API.Consumer.Utilities;

namespace DHSC.ANS.API.Consumer.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddHSA4Validators(this IServiceCollection services)
	{
		
		services.AddScoped<IValidator<HSA4Form>, HSA4FormValidator>();

        // Add the combined validation service
        services.AddTransient(typeof(IValidationService<>), typeof(ApiValidationService<>));

        // Add the service that packages validation errors
        services.AddTransient<IValidationResponseService, ValidationResponseService>();

        return services;
	}

	public static IServiceCollection AddHSA4FormService(this IServiceCollection services)
	{
		services.AddScoped<IHSA4FormService, HSA4FormService>();
		return services;
	}

    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        // Load embedded Markdown banner text
        var assembly = Assembly.GetExecutingAssembly();
        const string resourceName = "DHSC.ANS.API.Consumer.Assets.Banner.md";

        string bannerText = "API for submitting HSA4 Abortion Notification Forms.";
        var resourceStream = assembly.GetManifestResourceStream(resourceName);
        if (resourceStream != null)
        {
            using (var reader = new StreamReader(resourceStream))
            {
                bannerText = reader.ReadToEnd();
            }
        }

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "DHSC.ANS.API",
                Version = "v1",
                Description = bannerText,
                Contact = new OpenApiContact { Name = "DHSC", Url = new Uri("https://www.gov.uk") }
            });

            c.SchemaFilter<EnumSchemaFilter>();

            // Include XML Comments
            var xmlFile = $"{assembly.GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            if (File.Exists(xmlPath))
            {
                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
                c.SchemaFilter<RemarksSchemaFilter>(xmlPath);
            }

            c.SchemaFilter<RestrictionsAttributeSchemaFilter>();

            c.EnableAnnotations();

            // Add JWT Bearer security definition and requirement
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "Bearer",
                    Name = "Bearer",
                    In = ParameterLocation.Header
                },
                new List<string>()
            }
        });
        });

        return services;
    }


    public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
	{
		app.UseSwagger();
		app.UseSwaggerUI(c =>
		{
			c.SwaggerEndpoint("/swagger/v1/swagger.json", "Consumer API v1");
			c.RoutePrefix = string.Empty;

			// Optionally tweak UI settings
			c.DocumentTitle = "DHSC ANS - HSA4 Submission";
			//c.DefaultModelsExpandDepth(-1); // hide schema models by default
			//c.DocExpansion(DocExpansion.None);
		});

		return app;
	}
}
