using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityModel
{
    public class Item : ModelBase
    {
        public int BookId { get; set; }

        public int OrderId { get; set; }

        public int Quantity { get; set; }

        public Book Book { get; set; }

        public Order Order { get; set; }
    }
}
