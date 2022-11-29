using HotChocolate.AspNetCore.Instrumentation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace Graphir.API.AppInsights;

public class ServerEventListener : ServerDiagnosticEventListener
{
    private readonly ILogger<ServerEventListener> _logger;

    public ServerEventListener(ILoggerFactory logFactory) 
        => _logger = logFactory.CreateLogger<ServerEventListener>();

    public override IDisposable ExecuteHttpRequest(HttpContext context, HttpRequestKind kind)
    {
        return new RequestScope(DateTime.Now, _logger);
    }
}

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

        _logger.LogInformation("Request finished after {Ticks} ticks",
            elapsed.Ticks);
    }
}
