using AutoMapper;
using DataAccessLayer.EntityModel;
using DataAccessLayer.Repository;
using MediatorDesignPatternLibrary.Model;
using MediatorHandler.RepositoryInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorHandler.Handler.ItemHandler
{
    public class UpdateItemRequest : IRequest
    {
        public ItemDAO Item { get; set; }
    }

    public class UpdateOrderHandler : HandlerBase, IRequestHandler<UpdateItemRequest, Unit>
    {
        private readonly IItemRepository _repository;

        public UpdateOrderHandler(IUnitOfWork unitOfWork, IMapper mapper, IItemRepository orderRepository) : base(unitOfWork, mapper)
        {
            _repository = orderRepository;
        }

        public async Task<Unit> Handle(UpdateItemRequest request, CancellationToken cancellationToken)
        {
            await _repository.ModifyAsync(_mapper.Map<Item>(request.Item));
            await _unitOfWork.SaveChangeAsync();
            return await Task.FromResult(Unit.Value);
        }
    }
}
