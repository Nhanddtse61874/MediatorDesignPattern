using AutoMapper;
using DataAccessLayer.EntityModel;
using DataAccessLayer.Repository;
using DataAccessLayer.RepositoryInterface;
using MediatorDesignPatternLibrary.Model;
using MediatR;

namespace MediatorHandler.Handler.BookHandler
{
    public class AddBookRequest : IRequest
    {
        public BookDAO Book { get; set; }
    }

    public class AddBookHandler : HandlerBase, IRequestHandler<AddBookRequest, Unit>
    {
        private readonly IBookRepository _repository;

        public AddBookHandler(IUnitOfWork unitOfWork, IMapper mapper, IBookRepository bookRepository) : base(unitOfWork, mapper)
        {
            _repository = bookRepository;
        }

        public async  Task<Unit> Handle(AddBookRequest request, CancellationToken cancellationToken) 
        {
            await _repository.AddAsync(_mapper.Map<Book>(request.Book));
            await _unitOfWork.SaveChangeAsync();
            return await Task.FromResult(Unit.Value);   
        }
    }
}
