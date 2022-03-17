using AutoMapper;
using DataAccessLayer.EntityModel;
using DataAccessLayer.Repository;
using DataAccessLayer.RepositoryInterface;
using MediatorDesignPatternLibrary.Model;
using MediatR;

namespace MediatorHandler.Handler.BookHandler
{
    public class GetAllBookRequest : IRequest<List<BookDAO>>
    {

    }

    public class GetAllOrderHandler : HandlerBase, IRequestHandler<GetAllBookRequest, List<BookDAO>>
    {
        private readonly IBookRepository _repository;

        public GetAllOrderHandler(IUnitOfWork unitOfWork, IMapper mapper, IBookRepository bookRepository) : base(unitOfWork, mapper)
        {
            _repository = bookRepository;
        }

        public async Task<List<BookDAO>> Handle(GetAllBookRequest request, CancellationToken cancellationToken)
        {
            var result = _repository.GetAll();
            return _mapper.Map<List<BookDAO>>(result);
        }
    }
}
