using System;
using Microsoft.Extensions.Logging;

namespace Graphir.API.AppInsights;

public class RequestScope : IDisposable
{
    private readonly ILogger _logger;
    private readonly DateTime _start;

    public RequestScope(DateTime start, ILogger logger)
    {
        _start = start;
        _logger = logger;
    }

    // this is invoked at the end of the `ExecuteRequest` operation
    public void Dispose()
    {
        var end = DateTime.UtcNow;
        var elapsed = end - _start;

        _logger.LogInformation("Request finished after {Ticks} ticks / {Milliseconds} milliseconds",
            elapsed.Ticks, elapsed.TotalMilliseconds);
    }
}