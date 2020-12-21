using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedirectTemplate.Application
{
    public class CustomDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var oap = new OpenApiPaths();
            foreach (var p in swaggerDoc.Paths)
            {
                oap.Add(p.Key.Replace("v{version}", swaggerDoc.Info.Version), p.Value);
            }
            swaggerDoc.Paths = oap;
        }
    }
}
