using Application.Exceptions;
using Application.Responses.Common;
using Newtonsoft.Json;
using SendGrid.Helpers.Errors.Model;
using System.Net;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            } catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = new BaseResponse();
            response.Success = false;
            var statusCode = HttpStatusCode.InternalServerError;
            response.Message = exception.Message;

            switch (exception)
            {
                case BadRequestException badRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    response.Message = badRequestException.Message;
                    break;
                case UserNotFoundException userNotFoundException1:
                    statusCode = HttpStatusCode.NotFound;
                    response.Message = userNotFoundException1.Message;
                    break;
                case AuthCredentialsException authCredentialsException: 
                    statusCode = HttpStatusCode.BadRequest;
                    response.Message = authCredentialsException.Message;
                    break;
                default:
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
