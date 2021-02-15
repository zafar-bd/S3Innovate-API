using S3Inovate.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S3Inovate.Core.Servies.Abstractions
{
    public interface IObjectService
    {
        Task<IReadOnlyCollection<ObjectVm>> GetObjectsAsync();
    }
}
