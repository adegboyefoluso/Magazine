using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.Data
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Guid OwnerId { get; set; }
       

    }
}
