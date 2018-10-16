﻿using System.Threading;
using System.Threading.Tasks;
using Flowsharp.Models;

namespace Flowsharp.Results
{
    /// <summary>
    /// Halts workflow execution.
    /// </summary>
    public class HaltResult : ActivityExecutionResult
    {
        public override async Task ExecuteAsync(IWorkflowInvoker invoker, WorkflowExecutionContext workflowContext, CancellationToken cancellationToken)
        {            
            if (workflowContext.IsFirstPass)
            {
                var activity = workflowContext.CurrentActivity;
                var result = await invoker.ActivityInvoker.ResumeAsync(activity, workflowContext, cancellationToken);
                workflowContext.IsFirstPass = false;

                await result.ExecuteAsync(invoker, workflowContext, cancellationToken);
            }
            else
            {
                await workflowContext.HaltAsync(cancellationToken);
            }
        }
    }
}
