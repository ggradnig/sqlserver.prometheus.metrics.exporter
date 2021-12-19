﻿using SqlServer.Metrics.Provider;
using System.Collections.Generic;
using System.Linq;

namespace Sqlserver.Metrics.Provider.Builder
{
    public class MinElapsedTimeMetricsBuilder : IMetricsBuilder
    {
        public MinElapsedTimeMetricsBuilder()
        {
        }

        public IEnumerable<MetricItem> Build(IGrouping<string, PlanCacheItem> groupedPlanCacheItems)
        {
            yield return new MetricItem()
            {
                Name = $"{groupedPlanCacheItems.Key}_ElapsedTimeMin",
                Value = groupedPlanCacheItems.Min(p => p.ExecutionStatistics.ElapsedTime.Min)
            };
        }
    }
}