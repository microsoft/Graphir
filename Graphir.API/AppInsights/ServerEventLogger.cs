using HotChocolate.AspNetCore.Instrumentation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace Graphir.API.AppInsights;

public class ServerEventLogger : ServerDiagnosticEventListener
{
    private readonly ILogger<ServerEventLogger> _logger;

    public ServerEventLogger(ILoggerFactory logFactory) 
        => _logger = logFactory.CreateLogger<ServerEventLogger>();

    public override IDisposable ExecuteHttpRequest(HttpContext context, HttpRequestKind kind)
    {
        return new RequestScope(DateTime.Now, _logger);
    }
}

