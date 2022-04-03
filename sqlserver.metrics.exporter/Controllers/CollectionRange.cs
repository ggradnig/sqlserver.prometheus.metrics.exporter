﻿using System;

namespace SqlServer.Metrics.Exporter.Controllers
{
    public class CollectionRange
    {
        public DateTime LastFetchTime { get; set; }
        public DateTime IncludedHistoricalItemsUntil { get; set; }
        public override string ToString()
        {
            return $"CollectionRange: LastFetchTime {LastFetchTime}, IncludedHistoricalItemsUntil = {IncludedHistoricalItemsUntil}";
        }
    }
}
