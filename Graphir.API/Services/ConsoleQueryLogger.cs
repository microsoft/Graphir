namespace Graphir.API.Services;

public class ConsoleQueryLogger<T> : ExecutionDiagnosticEventListener
{
    private readonly ILogger<ConsoleQueryLogger<T>> _logger;
    public ConsoleQueryLogger(ILogger<ConsoleQueryLogger<T>> logger) => _logger = logger;
        
    // this is invoked at the start of the `ExecuteRequest` operation
    public override IDisposable ExecuteRequest(IRequestContext context)
    {
        DateTime start = DateTime.UtcNow;
            
        return new RequestScope(start, _logger);
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
        DateTime end = DateTime.UtcNow;
        TimeSpan elapsed = end - _start;

        _logger.LogInformation("Request finished after {Ticks} ticks",
            elapsed.Ticks);
    }
}