
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DHSC.ANS.API.Consumer.Utilities;

public class RestrictionsAttributeSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        var type = context.Type;

        foreach (var property in type.GetProperties())
        {
            var attribute = property.GetCustomAttributes(typeof(RestrictionsAttribute), false)
                                     .FirstOrDefault() as RestrictionsAttribute;

            if (attribute != null)
            {
                var propertyKey = schema.Properties.Keys.FirstOrDefault(k => k.ToLower() == property.Name.ToLower());

                if (propertyKey != null)
                {
                    schema.Properties[propertyKey].Extensions.Add("x-restrictions", new Microsoft.OpenApi.Any.OpenApiString(attribute.Value));
                }
            }
        }
    }
}

public class RestrictionsAttribute : Attribute
{
    public string Value { get; }

    public RestrictionsAttribute(string value)
    {
        Value = value;
    }
}
