using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using S3Inovate.Core.Cqrs.Queries;
using S3Inovate.Core.Helpers;
using S3Inovate.Core.Servies.Abstractions;
using S3Inovate.Core.ViewModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace S3Inovate.Core.Cqrs.Handlers.Queries
{
    public class BuildingQueryHandler : IRequestHandler<BuildingQuery, IReadOnlyCollection<BuildingVm>>
    {
        private readonly IBuildingService _buildingService;
        private readonly IDistributedCache _distributedCache;

        public BuildingQueryHandler(
            IBuildingService buildingService,
            IDistributedCache distributedCache)
        {
            this._buildingService = buildingService;
            this._distributedCache = distributedCache;
        }

        public async Task<IReadOnlyCollection<BuildingVm>> Handle(BuildingQuery query,CancellationToken cancellationToken)
        {
            var cacheKey = $"buildings-all";

            var buildingsFromCache = await _distributedCache
                .GetCacheAsync<IReadOnlyCollection<BuildingVm>>(cacheKey);

            if (buildingsFromCache != null)
                return buildingsFromCache;

            var readingsFromDb = await _buildingService.GetBuildingsAsync();

            await _distributedCache
                .SetCacheAsStringAsync(cacheKey, readingsFromDb, 30);
            return readingsFromDb;
        }
    }
}
