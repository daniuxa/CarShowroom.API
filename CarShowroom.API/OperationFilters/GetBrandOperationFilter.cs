using CarShowroom.Bll.Models.BrandDTOs;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CarShowroom.Bll.OperationFilters
{
    /// <summary>
    /// Operation filter, used for adding schema for multiple endpoints
    /// </summary>
    public class GetBrandOperationFilter : IOperationFilter
    {
        /// <summary>
        /// Adding schemas
        /// </summary>
        /// <param name="operation">Operation which we want configure</param>
        /// <param name="context">Context of operation</param>
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
