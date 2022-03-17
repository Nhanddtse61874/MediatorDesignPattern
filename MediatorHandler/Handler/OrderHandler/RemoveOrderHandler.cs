using AutoMapper;
using DataAccessLayer.EntityModel;
using DataAccessLayer.Repository;
using DataAccessLayer.RepositoryInterface;
using MediatR;

namespace MediatorHandler.Handler.OrderHandler
{
    public class RemoveOrderRequest : IRequest
    {
        public int Id { get; set; }
    }
    public class RemoveOrderHandler : HandlerBase,IRequestHandler<RemoveOrderRequest>
    {
        private readonly IOrderRepository _repository;

        public RemoveOrderHandler(IUnitOfWork unitOfWork, IMapper mapper, IOrderRepository orderRepository) : base(unitOfWork, mapper)
        {
            _repository = orderRepository;
        }
        public async  Task<Unit> Handle(RemoveOrderRequest request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangeAsync();
            return await Task.FromResult(Unit.Value);
        }
    }
}
