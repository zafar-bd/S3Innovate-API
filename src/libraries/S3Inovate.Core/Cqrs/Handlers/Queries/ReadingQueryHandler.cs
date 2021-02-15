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
    public class ReadingQueryHandler : IRequestHandler<ReadingQuery, IReadOnlyCollection<ReadingVm>>
    {
        private readonly IReadingService _readingService;
        private readonly IDistributedCache _distributedCache;

        public ReadingQueryHandler(
            IReadingService readingService,
            IDistributedCache distributedCache)
        {
            this._readingService = readingService;
            this._distributedCache = distributedCache;
        }

        public async Task<IReadOnlyCollection<ReadingVm>> Handle(ReadingQuery args, CancellationToken cancellationToken)
        {
            args.ToDate = args.ToDate.ToEndOfTheDate();

            var cacheKey = $"reading-{args.BuildingId}-{args.ObjectId}-{args.DataFieldId}-{args.FromDate}-{args.ToDate}";

            var readingsFromCache = await _distributedCache
                .GetCacheAsync<IReadOnlyCollection<ReadingVm>>(cacheKey);

            if (readingsFromCache != null)
                return readingsFromCache;

            var readingsFromDb = await _readingService
                .GetReadingsAsync(args);

            await _distributedCache
                .SetCacheAsStringAsync(cacheKey, readingsFromDb, 30);
            return readingsFromDb;
        }
    }
}
