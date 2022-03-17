using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityModel
{
    public class Book : ModelBase
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public int Quantity { get; set; }

        public ICollection<Item> Items { get; set; }

    }
}
