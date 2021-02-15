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
    public class DataFieldQueryHandler : IRequestHandler<DataFieldsQuery, IReadOnlyCollection<DataFieldVm>>
    {
        private readonly IDataFieldService _dataFieldService;
        private readonly IDistributedCache _distributedCache;

        public DataFieldQueryHandler(
            IDataFieldService dataFieldService,
            IDistributedCache distributedCache)
        {
            this._dataFieldService = dataFieldService;
            this._distributedCache = distributedCache;
        }

        public async Task<IReadOnlyCollection<DataFieldVm>> Handle(DataFieldsQuery query,CancellationToken cancellationToken)
        {
            var cacheKey = $"datafields-all";

            var dataFieldssFromCache = await _distributedCache
                .GetCacheAsync<IReadOnlyCollection<DataFieldVm>>(cacheKey);

            if (dataFieldssFromCache != null)
                return dataFieldssFromCache;

            var readingsFromDb = await _dataFieldService.GetDataFieldsAsync();

            await _distributedCache
                .SetCacheAsStringAsync(cacheKey, readingsFromDb, 30);
            return readingsFromDb;
        }
    }
}
