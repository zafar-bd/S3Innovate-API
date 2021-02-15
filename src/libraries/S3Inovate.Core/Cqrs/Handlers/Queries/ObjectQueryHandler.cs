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
    public class ObjectQueryHandler : IRequestHandler<ObjectQuery, IReadOnlyCollection<ObjectVm>>
    {
        private readonly IObjectService _objectService;
        private readonly IDistributedCache _distributedCache;

        public ObjectQueryHandler(
            IObjectService objectService,
            IDistributedCache distributedCache)
        {
            this._objectService = objectService;
            this._distributedCache = distributedCache;
        }

        public async Task<IReadOnlyCollection<ObjectVm>> Handle(ObjectQuery query,CancellationToken cancellationToken)
        {
            var cacheKey = $"objets-all";

            var objectsFromCache = await _distributedCache
                .GetCacheAsync<IReadOnlyCollection<ObjectVm>>(cacheKey);

            if (objectsFromCache != null)
                return objectsFromCache;

            var objectsFromDb = await _objectService.GetObjectsAsync();

            await _distributedCache
                .SetCacheAsStringAsync(cacheKey, objectsFromDb, 30);
            return objectsFromDb;
        }
    }
}
