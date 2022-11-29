using System;
using System.Collections.Generic;
using System.Linq;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Execution.Instrumentation;
using HotChocolate.Resolvers;
using Microsoft.Extensions.Logging;

namespace Graphir.API.AppInsights;

public class ExecutionEventLogger : ExecutionDiagnosticEventListener
{
    private readonly ILogger<ExecutionEventLogger> _logger;
    public ExecutionEventLogger(ILoggerFactory factory) => _logger = factory.CreateLogger<ExecutionEventLogger>();

    // this is invoked at the start of the `ExecuteRequest` operation
    public override IDisposable ExecuteRequest(IRequestContext context)
    {
        var start = DateTime.UtcNow;
        return new RequestScope(start, _logger);
    }

    public override void RequestError(IRequestContext context, Exception exception)
    {
        _logger.LogError(exception.Message);
        base.RequestError(context, exception);
    }

    public override void ResolverError(IMiddlewareContext context, IError error)
    {
        _logger.LogError(error.Message);
        base.ResolverError(context, error);
    }

    public override void SyntaxError(IRequestContext context, IError error)
    {
        _logger.LogError(error.Message);
        base.SyntaxError(context, error);
    }

    public override void TaskError(IExecutionTask task, IError error)
    {
        _logger.LogError(error.Message);
        base.TaskError(task, error);
    }

    public override void ValidationErrors(IRequestContext context, IReadOnlyList<IError> errors)
    {
        _logger.LogError($"Validation failed with {errors.Count} error(s).");
        errors.ToList().ForEach(e => _logger.LogError(e.Message));
        base.ValidationErrors(context, errors);
    }
}
