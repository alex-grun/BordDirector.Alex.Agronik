using BordDirector.Alex.Agronik.Infra.Attributes;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BordDirector.Alex.Agronik.Utilities
{
    public class SwaggerSkipPropertyFilter : ISchemaFilter
    {
        public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
        {
            if (schema?.properties == null)
            {
                return;
            }

            var skipProperties = type.GetProperties().Where(t => t.GetCustomAttribute<SwaggerIgnore>() != null);

            foreach (var skipProperty in skipProperties)
            {
                var propertyToSkip = schema.properties.Keys.SingleOrDefault(x => string.Equals(x, skipProperty.Name, StringComparison.OrdinalIgnoreCase));

                if (propertyToSkip != null)
                {
                    schema.properties.Remove(propertyToSkip);
                }
            }
        }
    }
}