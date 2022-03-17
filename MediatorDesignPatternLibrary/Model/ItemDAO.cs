using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDesignPatternLibrary.Model
{
    public class ItemDAO : ModelBase
    {
        public int BookId { get; set; }

        public int OrderId { get; set; }

        public int Quantity { get; set; }
    }
}
