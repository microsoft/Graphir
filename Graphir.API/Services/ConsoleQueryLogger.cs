using System;
using HotChocolate.Execution;
using HotChocolate.Execution.Instrumentation;
using Microsoft.Extensions.Logging;

using static System.DateTime;

namespace Graphir.API.Services;

public class ConsoleQueryLogger : ExecutionDiagnosticEventListener
{
    private readonly ILogger<ConsoleQueryLogger> _logger;
    public ConsoleQueryLogger(ILogger<ConsoleQueryLogger> logger) => _logger = logger;
        
    // this is invoked at the start of the `ExecuteRequest` operation
    public override IDisposable ExecuteRequest(IRequestContext context) => new RequestScope(UtcNow, _logger);
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
        var elapsed = UtcNow - _start;

        _logger.LogInformation("Request finished after {Ticks} ticks / {Milliseconds} milliseconds", 
            elapsed.Ticks, elapsed.TotalMilliseconds);
    }
}