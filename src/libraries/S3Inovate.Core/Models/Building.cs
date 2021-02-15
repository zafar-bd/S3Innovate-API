using System.Collections.Generic;

namespace S3Inovate.Core.Models
{
    public class Building
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public ICollection<Reading> Readings { get; set; }
        = new List<Reading>();
    }
}
