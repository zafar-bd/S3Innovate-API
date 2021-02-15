using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using S3Inovate.Core.Context;
using S3Inovate.Core.Cqrs.Queries;
using S3Inovate.Core.Servies.Abstractions;
using S3Inovate.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S3Inovate.Core.Servies.Implementations
{
    public class ReadingService : IReadingService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public ReadingService(AppDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public async Task<IReadOnlyCollection<ReadingVm>> GetReadingsAsync(ReadingQuery args)
        {
            var query = _dbContext
                       .Readings
                       .Where(r => r.BuildingId == args.BuildingId
                                && r.ObjectId == args.ObjectId
                                && r.DataFieldId == args.DataFieldId);

            var requiredReadings = await query
                       .Where(r => r.Timestamp >= args.FromDate
                                && r.Timestamp <= args.ToDate)
                       .OrderBy(b => b.Timestamp)
                       .ProjectTo<ReadingVm>(_mapper.ConfigurationProvider)
                       .ToListAsync();

            if (!requiredReadings.Any())
                return new List<ReadingVm>();

            var lastRow = await query
            .OrderByDescending(r => r.Timestamp)
            .ProjectTo<ReadingVm>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

            var requiredLastReadingsRow = requiredReadings.LastOrDefault();

            if (!(lastRow.Timestamp == requiredLastReadingsRow.Timestamp
               && lastRow.Value == requiredLastReadingsRow.Value))
            {
                requiredReadings.Add(lastRow);
            }

            return requiredReadings;
        }
    }
}
