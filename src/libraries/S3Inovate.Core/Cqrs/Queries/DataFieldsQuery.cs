using MediatR;
using S3Inovate.Core.ViewModels;
using System.Collections.Generic;

namespace S3Inovate.Core.Cqrs.Queries
{
    public class DataFieldsQuery : IRequest<IReadOnlyCollection<DataFieldVm>>
    {
    }
}
