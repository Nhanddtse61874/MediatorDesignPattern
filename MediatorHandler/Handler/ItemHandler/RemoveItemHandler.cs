using AutoMapper;
using DataAccessLayer.Repository;
using MediatorHandler.RepositoryInterface;
using MediatR;

namespace MediatorHandler.Handler.ItemHandler
{
    public class RemoveItemRequest : IRequest
    {
        public int Id { get; set; }
    }
    public class RemoveBookHandler : HandlerBase, IRequestHandler<RemoveItemRequest, Unit>
    {
        private readonly IItemRepository _repository;

        public RemoveBookHandler(IUnitOfWork unitOfWork, IMapper mapper, IItemRepository bookRepository) : base(unitOfWork, mapper)
        {
            _repository = bookRepository;
        }

        public async Task<Unit> Handle(RemoveItemRequest request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangeAsync();
            return await Task.FromResult(Unit.Value);
        }
    }
}
