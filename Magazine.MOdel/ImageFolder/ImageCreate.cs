using Magazine.MOdel.EventFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Magazine.MOdel.ImageFolder
{
    public class ImageCreate
    {
       
        public HttpPostedFileBase File { get; set; }
        public int EventId { get; set; }
        public string ImgageInfo { get; set; }
        public IEnumerable<EventListItem> Events { get; set; }

    }
}
