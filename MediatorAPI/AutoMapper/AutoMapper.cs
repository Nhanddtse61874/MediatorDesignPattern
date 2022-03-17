using AutoMapper;
using DataAccessLayer.EntityModel;
using MediatorAPI.ViewModel;
using MediatorDesignPatternLibrary.Model;

namespace MediatorAPI.AutoMapper
{
    public class AutoMapper : Profile
    {
        protected IMapper _mapper;

        public AutoMapper()
        {
            CreateMap<Order, OrderDAO>().ReverseMap();
            CreateMap<Book, BookDAO>().ReverseMap();
            CreateMap<Item, ItemDAO>().ReverseMap();

            CreateMap<OrderViewModel, OrderDAO>().ReverseMap();
            CreateMap<BookViewModel, BookDAO>().ReverseMap();
            CreateMap<ItemViewModel, ItemDAO>().ReverseMap();

            CreateMap<CreatedBookViewModel, BookDAO>().ReverseMap();
            CreateMap<Book, CreatedBookDAO>().ReverseMap();
        }
    }
}
