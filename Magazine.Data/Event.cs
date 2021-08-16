using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.Data
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public Guid OwnerId { get; set; }

        public string FileName { get; set; }
        public byte[] FileContent { get; set; }

        public DateTime EventDate { get; set; }
        public string EventDetails { get; set; }
        
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public string EventHightlight { get; set; }
        public virtual Category Category { get; set; }


    }
}
