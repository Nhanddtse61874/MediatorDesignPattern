using AutoMapper;
using DataAccessLayer.EntityModel;
using DataAccessLayer.Repository;
using DataAccessLayer.RepositoryInterface;
using MediatR;

namespace MediatorHandler.Handler.BookHandler
{
    public class RemoveBookRequest : IRequest
    {
        public int Id { get; set; }
    }
    public class RemoveBookHandler : HandlerBase, IRequestHandler<RemoveBookRequest, Unit>
    {
        private readonly IBookRepository _repository;

        public RemoveBookHandler(IUnitOfWork unitOfWork, IMapper mapper, IBookRepository bookRepository) : base(unitOfWork, mapper)
        {
            _repository = bookRepository;
        }

        public async Task<Unit> Handle(RemoveBookRequest request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangeAsync();
            return await Task.FromResult(Unit.Value);
        }
    }
}
