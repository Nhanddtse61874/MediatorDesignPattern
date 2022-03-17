using MediatorDesignPatternLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDesignPatternLibrary.Interface
{
    public interface IOrderService
    {
        IList<Order> Add(Order order, IList<Order> list);

        IList<Order> Remove(Order order,IList<Order> list);

        IList<Order> Update( Order order,IList<Order> list);   
    }

    public interface IBookService
    {
        IList<Book> Add(Book book, IList<Book> list);

        IList<Book> Remove(Book book, IList<Book> list);

        IList<Book> Update(Book book, IList<Book> list);
    }

    public interface IItemService
    {
        IList<Item> Add(Item item, IList<Item> list);

        IList<Item> Remove(Item item, IList<Item> list);
    }
}
