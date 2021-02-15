using MediatR;
using S3Inovate.Core.ViewModels;
using System;
using System.Collections.Generic;

namespace S3Inovate.Core.Cqrs.Queries
{
    public class ReadingQuery : IRequest<IReadOnlyCollection<ReadingVm>>
    {
        public ushort? BuildingId { get; set; }
        public byte? ObjectId { get; set; }
        public byte? DataFieldId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
