using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.MOdel.ImageFolder
{
    public class ImageListItem
    {
        public int ImageId { get; set; }
        public byte[] FileContent { get; set; }
        public string ImgageInfo { get; set; }
        public int EventId { get; set; }
        public string  EventDetails { get; set; }

        public string  Eventhighlight { get; set; }
    }
}
