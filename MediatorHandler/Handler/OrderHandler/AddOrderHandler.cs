using AutoMapper;
using DataAccessLayer.EntityModel;
using DataAccessLayer.Repository;
using DataAccessLayer.RepositoryInterface;
using MediatorDesignPatternLibrary.Model;
using MediatR;

namespace MediatorHandler
{
    public class AddOrderRequest : IRequest
    {
        public OrderDAO Order { get; set; }
    }

    
    public class AddOrderHandler : HandlerBase, IRequestHandler<AddOrderRequest, Unit>
    {
        private readonly IOrderRepository _repository;

        public AddOrderHandler(IUnitOfWork unitOfWork, IMapper mapper, IOrderRepository orderRepository) : base(unitOfWork, mapper)
        {
            _repository = orderRepository;
        }

        public async  Task<Unit> Handle(AddOrderRequest request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(_mapper.Map<Order>(request));
            await _unitOfWork.SaveChangeAsync();
            return await Task.FromResult(Unit.Value);
        }
    }
}
