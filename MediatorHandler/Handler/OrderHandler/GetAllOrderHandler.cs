using AutoMapper;
using DataAccessLayer.EntityModel;
using DataAccessLayer.Repository;
using DataAccessLayer.RepositoryInterface;
using MediatorDesignPatternLibrary.Model;
using MediatR;

namespace MediatorHandler.Handler.OrderHandler
{
    public class GetAllOrderRequest : IRequest<List<OrderDAO>>
    {

    }

    public class GetAllOrderHandler : HandlerBase, IRequestHandler<GetAllOrderRequest, List<OrderDAO>>
    {
        private readonly IOrderRepository _repository;

        public GetAllOrderHandler(IUnitOfWork unitOfWork, IMapper mapper, IOrderRepository orderRepository) : base(unitOfWork, mapper)
        {
            _repository = orderRepository;
        }

        public async Task<List<OrderDAO>> Handle(GetAllOrderRequest request, CancellationToken cancellationToken)
        {
            var result = _repository.GetAll();
            return _mapper.Map<List<OrderDAO>>(result);
        }
    }
}
