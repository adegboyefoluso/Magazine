using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.Data
{
    public class Image
    {
        public int ImageId { get; set; }
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
        public string ImgageInfo { get; set; }

        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
