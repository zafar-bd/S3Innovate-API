using System.Collections.Generic;

namespace S3Inovate.Core.Models
{
    public class DataField
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public ICollection<Reading> Readings { get; set; }
        = new List<Reading>();
    }
}
