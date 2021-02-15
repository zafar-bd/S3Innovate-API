using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using S3Inovate.Core.Context;
using S3Inovate.Core.Servies.Abstractions;
using S3Inovate.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S3Inovate.Core.Servies.Implementations
{
    public class BuildingService : IBuildingService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public BuildingService(AppDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public async Task<IReadOnlyCollection<BuildingVm>> GetBuildingsAsync()
        => await
            _dbContext
            .Buildings
            .OrderBy(b => b.Name)
            .ThenBy(b => b.Location)
            .ProjectTo<BuildingVm>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}
