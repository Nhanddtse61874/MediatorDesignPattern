using AutoMapper;
using DataAccessLayer.EntityModel;
using DataAccessLayer.Repository;
using DataAccessLayer.RepositoryInterface;
using MediatorDesignPatternLibrary.Model;
using MediatR;

namespace MediatorHandler.Handler.OrderHandler
{
    public class UpdateOrderRequest : IRequest
    {
        public OrderDAO Order { get; set; }
    }

    public class UpdateOrderHandler : HandlerBase, IRequestHandler<UpdateOrderRequest, Unit>
    {
        private readonly IOrderRepository _repository;

        public UpdateOrderHandler(IUnitOfWork unitOfWork, IMapper mapper, IOrderRepository orderRepository) : base(unitOfWork, mapper)
        {
            _repository = orderRepository;
        }

        public async Task<Unit> Handle(UpdateOrderRequest request, CancellationToken cancellationToken)
        {
            await _repository.ModifyAsync(_mapper.Map<Order>(request.Order));
            await _unitOfWork.SaveChangeAsync();
            return await Task.FromResult(Unit.Value);
        }
    }
}
