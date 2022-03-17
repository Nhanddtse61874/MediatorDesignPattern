using AutoMapper;
using DataAccessLayer.EntityModel;
using DataAccessLayer.Repository;
using DataAccessLayer.RepositoryInterface;
using MediatorDesignPatternLibrary.Model;
using MediatR;

namespace MediatorHandler.Handler.BookHandler
{
    public class UpdateBookRequest : IRequest
    {
        public BookDAO Book { get; set; }
    }

    public class UpdateBookHandler : HandlerBase, IRequestHandler<UpdateBookRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _repository;

        public UpdateBookHandler(IUnitOfWork unitOfWork, IMapper mapper, IBookRepository orderRepository) : base(unitOfWork, mapper)
        {
            _mapper = mapper;
            _repository = orderRepository;
        }

        public async Task<Unit> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
        {
            await _repository.ModifyAsync(_mapper.Map<Book>(request.Book));
            await _unitOfWork.SaveChangeAsync();
            return await Task.FromResult(Unit.Value);
        }
    }
}
