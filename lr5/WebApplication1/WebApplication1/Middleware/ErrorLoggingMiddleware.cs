using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;



public class ErrorLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            LogExceptionToFile(ex);
            throw;
        }
    }

    private void LogExceptionToFile(Exception ex)
    {
        string logFilePath = "error.log";
        File.AppendAllText(logFilePath, $"{DateTime.Now}: {ex.Message}{Environment.NewLine}");
    }
}