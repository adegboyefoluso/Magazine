using Magazine.MOdel.CategoryFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Magazine.MOdel.EventFolder
{
    public class EventCreate
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string EventDetails { get; set; }
        public string EventHigghtLight { get; set; }
        public HttpPostedFileBase File { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<CategoryListItem> Categories { get; set; }
    }
}
