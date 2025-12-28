using TicketManager.Model.ModelsNotMapped.Exceptions;

namespace TicketManager.API.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    private const int ModelExceptionStatusCode = 400;
    private const int ExceptionStatusCode = 500;
    private const int ServiceExceptionStatusCode = 503;
    private const int UnauthorizedAccessStatusCode = 403;

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (ModelException ex)
        {
            await HandleExceptionAsync(httpContext, ex, ModelExceptionStatusCode, ex.ErrorObject);
        }
        catch (ServiceException ex)
        {
            await HandleExceptionAsync(httpContext, ex, ServiceExceptionStatusCode, ex.ErrorObject);
        }
        catch (UnauthorizedAccessException ex)
        {
            await HandleExceptionAsync(httpContext, ex, UnauthorizedAccessStatusCode);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex, ExceptionStatusCode);
        }
    }

    private async Task HandleExceptionAsync(
        HttpContext context,
        Exception exception,
        int statusCode,
        object? objetoErro = null)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;
        ErrorDetails errorDetails= new ErrorDetails(
            context.Response.StatusCode,
            exception.Message,
            objetoErro);

        await context.Response.WriteAsync(errorDetails.ToString());
    }
}