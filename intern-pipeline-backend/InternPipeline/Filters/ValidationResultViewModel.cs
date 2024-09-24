using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InternPipeline.Filters
{
    public class ValidationResultModel
    {
        public int code { get; set; }
        public string message { get; set; }
        public string data { get; set; }
        public List<ErrorResponseData> errors { get; set; } = new List<ErrorResponseData>();
        public class ErrorResponseData
        {
            public string error_code { get; set; }
            public string error_message { get; set; }
            public ErrorResponseData(string errorCode = "", string errorMessage = "")
            {
                error_code = errorCode;
                error_message = errorMessage;
            }
        }
        public ValidationResultModel(ModelStateDictionary modelState, HttpContext httpContext)
        {

            try
            {
                code = StatusCodes.Status422UnprocessableEntity;
                message = "Validation Failed";
                data = null;
                foreach (var modelStateKey in modelState.Keys)
                {
                    var modelStateVal = modelState[modelStateKey];
                    foreach (var error in modelStateVal.Errors)
                    {
                        errors.Add(new ErrorResponseData("1050", error.ErrorMessage));
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
