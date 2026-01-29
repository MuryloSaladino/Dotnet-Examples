using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Behaviors;

public class LoggingBehavior<TRequest, TResponse>(
    ILogger<TRequest> logger
) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly Stopwatch stopwatch = new();

    public async Task<TResponse> Handle(
        TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        stopwatch.Start();
        var response = await next();
        stopwatch.Stop();

        var requestName = typeof(TRequest).Name;
        var now = DateTime.UtcNow.ToString();
        var took = stopwatch.ElapsedMilliseconds;

        logger.LogInformation("Successful {requestName} at {now} UTC Time | Took {took} ms",
            requestName, now, took);

        return response;
    }
}