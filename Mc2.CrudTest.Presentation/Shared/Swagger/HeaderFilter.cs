﻿using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Mc2.CrudTest.Shared.Swagger
{
    /// <summary>
    /// Operation filter to add the requirement of the custom header
    /// </summary>
    public class HeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "culture",
                In = ParameterLocation.Query,
                Description = "culture",
                Required = true
            });
        }
    }
}
