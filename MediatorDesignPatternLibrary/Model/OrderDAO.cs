using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDesignPatternLibrary.Model
{
    public class Order : ModelBase
    {
        public DateTime DateTime { get; set; }

        public double Price { get; set; }
    }

    public class OrderRequest : IRequest<List<Order>>
    {
        public  IList<Order> ListOrder { get; set; }

        public Order Order { get; set; }
    }

    public class OrderRequestRemove : IRequest<List<Order>>
    {
        public IList<Order> ListOrder { get; set; }

        public Order Order { get; set; }
    }
}
