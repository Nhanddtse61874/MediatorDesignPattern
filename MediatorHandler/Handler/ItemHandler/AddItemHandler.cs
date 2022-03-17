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
    public class AddItemRequest : IRequest
    {
        public ItemDAO Item { get; set; }
    }


    public class AddItemHandler : HandlerBase, IRequestHandler<AddItemRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IItemRepository _repository;

        public AddItemHandler(IUnitOfWork unitOfWork, IMapper mapper, IItemRepository itemRepository) : base(unitOfWork, mapper)
        {
            _mapper = mapper;
            _repository = itemRepository;
        }

        public async Task<Unit> Handle(AddItemRequest request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(_mapper.Map<Item>(request.Item));
            await _unitOfWork.SaveChangeAsync();
            return await Task.FromResult(Unit.Value);
        }
    }
}
