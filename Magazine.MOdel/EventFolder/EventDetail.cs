using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.MOdel.EventFolder
{
    public class EventDetail
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string EventDetails { get; set; }
        public byte[] FileContent { get; set; }

    }
}
