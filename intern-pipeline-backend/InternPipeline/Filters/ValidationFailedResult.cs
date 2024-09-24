using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace InternPipeline.Filters
{

    public class ValidationFailedResult : ObjectResult
    {
        private HttpContext httpContext;
        public ValidationFailedResult(ModelStateDictionary modelState, HttpContext httpContext)
            : base(new ValidationResultModel(modelState, httpContext))
        {
            StatusCode = StatusCodes.Status200OK;
        }
    }
}
