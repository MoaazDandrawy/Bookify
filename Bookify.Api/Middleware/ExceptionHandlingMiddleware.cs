using Bookify.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Api.Middleware
{
    //hoa 3aml el middleware da 3lshan 5atr y5aly shakl el errors kolha wa7ed w badl ma yktb try w catch f kol controller w handler by5ly el error handling markazy f makan wa7ed
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

                var exceptionDetails = GetExceptionDetails(exception);

                // el problem Details da standard type l el mvc 3lshan el errors tkon monzma w el front end bikoon mstny el error f el shakl da
                var problemDetails = new ProblemDetails
                {
                    Status = exceptionDetails.Status,
                    Type = exceptionDetails.Type,
                    Title = exceptionDetails.Title,
                    Detail = exceptionDetails.Detail,
                };
                if (exceptionDetails.Errors is not null)
                {
                    problemDetails.Extensions["errors"] = exceptionDetails.Errors;
                }
                context.Response.StatusCode = exceptionDetails.Status;
                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }
        private static ExceptionDetails GetExceptionDetails(Exception exception)
        {
            //hoa hena bi3ml switch 3la 7asb lw el exception elly gay lw validationException hairg3 instance mn ExceptionDetails bta3 400 lw ay 7aga tanya (Default) hairg3 500
            return exception switch
            {
                ValidationException validationException => new ExceptionDetails(
                    Status: StatusCodes.Status400BadRequest,
                    Type: "ValidationFailure",
                    Title: "Validation error",
                    Detail: "One or more validation errors has occurred here",
                    Errors: validationException.Errors),
                _ => new ExceptionDetails(
                    Status: StatusCodes.Status500InternalServerError,
                    Type: "ServerError",
                    Title: "Server error",
                    Detail: "An unexpected error has occurred",
                    Errors: null)
            };
        }
        internal record ExceptionDetails(int Status, string Type, string Title, string Detail, IEnumerable<object>? Errors);
    }
}
