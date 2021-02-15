using S3Inovate.Core.Cqrs.Queries;
using S3Inovate.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S3Inovate.Core.Servies.Abstractions
{
    public interface IReadingService
    {
        Task<IReadOnlyCollection<ReadingVm>> GetReadingsAsync(ReadingQuery args);
    }
}
