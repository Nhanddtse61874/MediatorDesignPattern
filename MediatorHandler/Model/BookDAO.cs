using DataAccessLayer;
using MediatorDesignPatternLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDesignPatternLibrary.Model
{
    public class BookDAO : ModelBase
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public int Quantity { get; set; }

        public ICollection<ItemDAO> Items { get; set; }

    }

    public class CreatedBookDAO 
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public int Quantity { get; set; }

    }
}
