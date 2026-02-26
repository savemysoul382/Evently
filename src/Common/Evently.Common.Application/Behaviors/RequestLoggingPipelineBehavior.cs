using Evently.Common.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;

#pragma warning disable CA1873

namespace Evently.Common.Application.Behaviors;

internal sealed class RequestLoggingPipelineBehavior<TRequest, TResponse>(ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    where TResponse : Result
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        string moduleName = GetModuleName(requestName: typeof(TRequest).FullName!);
        string requestName = typeof(TRequest).Name;

        using (LogContext.PushProperty(name: "Module", value: moduleName))
        {
            logger.LogInformation(message: "Processing request {RequestName}", args: requestName);

            TResponse result = await next();

            if (result.IsSuccess)
            {
                logger.LogInformation(message: "Completed request {RequestName}", args: requestName);
            }
            else
            {
                using (LogContext.PushProperty(name: "Error", value: result.Error, destructureObjects: true))
                {
                    logger.LogError(message: "Completed request {RequestName} with error", args: requestName);
                }
            }

            return result;
        }
    }

    private static string GetModuleName(string requestName) => requestName.Split(separator: '.')[2];
}
