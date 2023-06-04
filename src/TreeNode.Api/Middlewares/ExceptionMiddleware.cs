using MediatR;
using Newtonsoft.Json;
using TreeNode.Application.ExceptionRecords.Commands;
using TreeNode.Application.Exceptions;

namespace TreeNode.Api.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext, ISender sender)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong: {ex}");

            var eventId = Guid.NewGuid();
            var exceptionType = ex.GetType().Name;
            var exceptionMessage = ex.Message;

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            httpContext.Response.ContentType = "application/json";

            var createExceptionRecordCommand = new CreateExceptionRecordCommand(
                EventId: eventId,
                Timestamp: DateTime.UtcNow,
                Path: httpContext.Request.Path,
                Message: exceptionMessage,
                QueryParameters: GetParameterString(httpContext.Request.Query),
                BodyParameters: await GetBodyParametersAsync(httpContext.Request),
                ExceptionStackTrace: ex.StackTrace
            );

            await sender.Send(createExceptionRecordCommand);

            var response = new ErrorDetails
            {
                Type = exceptionType,
                Id = eventId.ToString(),
                Data = new Data()
                {
                    Message = ex is SecureException ? exceptionMessage : $"Internal server error ID = {eventId}"
                }
            };

            var jsonResponse = JsonConvert.SerializeObject(response);

            // Write the JSON response to the response body
            await httpContext.Response.WriteAsync(jsonResponse);
        }
    }

    private string GetParameterString(IQueryCollection parameters)
    {
        return string.Join("&", parameters.Select(p => $"{p.Key}={p.Value}"));
    }

    private async Task<string> GetBodyParametersAsync(HttpRequest request)
    {
        if (request.ContentLength.HasValue && request.ContentLength > 0 && request.HasFormContentType)
        {
            var form = await request.ReadFormAsync();
            return string.Join("&", form.Select(p => $"{p.Key}={p.Value}"));
        }

        return string.Empty;
    }
}