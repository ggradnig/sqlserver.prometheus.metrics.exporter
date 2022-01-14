﻿using SqlServer.Metrics.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sqlserver.Metrics.Exporter.Database
{
    public class DbCacheRepositoryAdapter
    {
        private IDbPlanCacheRepository planCacheRepository;

        public DbCacheRepositoryAdapter(IDbPlanCacheRepository planCacheRepository)
        {
            this.planCacheRepository = planCacheRepository;
        }

        public async Task<IEnumerable<PlanCacheItem>> GetPlanCache(DateTime from)
        {
            var lookUp = await this.planCacheRepository.GetObjectIdAndProcedureNames();

            return
                (await this.planCacheRepository.GetCurrentPlanCache(from))
                .Concat(await this.planCacheRepository.GetHistoricalPlanCache(from))
                .Select(p => { p.SpName = lookUp[p.ObjectId]; return p; });
        }
    }
}