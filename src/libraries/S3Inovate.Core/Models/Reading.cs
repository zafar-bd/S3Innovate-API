using System;

namespace S3Inovate.Core.Models
{
    public class Reading
    {
        public short BuildingId { get; set; }
        public byte ObjectId { get; set; }
        public byte DataFieldId { get; set; }
        public decimal Value { get; set; }
        public DateTime Timestamp { get; set; }

        public Building Building { get; set; }
        public Object Object { get; set; }
        public DataField DataField { get; set; }
    }
}
