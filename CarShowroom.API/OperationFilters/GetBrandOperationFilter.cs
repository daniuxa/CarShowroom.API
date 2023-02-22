using CarShowroom.Bll.Models.BrandDTOs;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.OperationFilters
{
    public class GetBrandOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.OperationId != "GetBrand")
            {
                return;
            }
            if (operation.Responses.Any(responses => responses.Key == StatusCodes.Status200OK.ToString()))
            {
                var schema = context.SchemaGenerator.GenerateSchema(typeof(BrandWithModelsDTO), context.SchemaRepository);
                operation.Responses[StatusCodes.Status200OK.ToString()]
                    .Content.Add("application/vnd.media.brandwithmodels+json",
                    new OpenApiMediaType() { Schema = schema });
            }
        }
    }
}
