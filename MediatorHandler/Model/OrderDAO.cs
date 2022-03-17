using DataAccessLayer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDesignPatternLibrary.Model
{
    public class OrderDAO : ModelBase
    {
        public DateTime DateTime { get; set; }

        public double Price { get; set; }

        public List<ItemDAO> Items { get; set; }
    }

   
}
