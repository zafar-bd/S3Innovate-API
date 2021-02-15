using MediatR;
using S3Inovate.Core.ViewModels;
using System.Collections.Generic;

namespace S3Inovate.Core.Cqrs.Queries
{
    public class ObjectQuery : IRequest<IReadOnlyCollection<ObjectVm>>
    {
    }
}
