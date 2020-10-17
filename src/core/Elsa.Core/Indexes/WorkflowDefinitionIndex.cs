﻿using Elsa.Models;
using YesSql.Indexes;

namespace Elsa.Indexes
{
    public class WorkflowDefinitionIndex : MapIndex
    {
        public string WorkflowDefinitionId { get; set; } = default!;
        public string WorkflowDefinitionVersionId { get; set; } = default!;
        public int Version { get; set; }
        public bool IsLatest { get; set; }
        public bool IsPublished { get; set; }
        public bool IsEnabled { get; set; }
    }
    
    public class WorkflowDefinitionIndexProvider : IndexProvider<WorkflowDefinition>
    {
        public override void Describe(DescribeContext<WorkflowDefinition> context)
        {
            context.For<WorkflowDefinitionIndex>()
                .Map(
                    workflowDefinition => new WorkflowDefinitionIndex
                    {
                        WorkflowDefinitionId = workflowDefinition.WorkflowDefinitionId,
                        WorkflowDefinitionVersionId = workflowDefinition.WorkflowDefinitionVersionId,
                        Version = workflowDefinition.Version,
                        IsPublished = workflowDefinition.IsPublished,
                        IsLatest = workflowDefinition.IsLatest,
                        IsEnabled = workflowDefinition.IsEnabled
                    }
                );
        }
    }
}