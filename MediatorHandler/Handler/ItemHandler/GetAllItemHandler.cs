using AutoMapper;
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
    public class GetAllItemRequest : IRequest<List<ItemDAO>>
    {

    }

    public class GetAllItemHandler : HandlerBase, IRequestHandler<GetAllItemRequest, List<ItemDAO>>
    {
        private readonly IItemRepository _repository;

        public GetAllItemHandler(IUnitOfWork unitOfWork, IMapper mapper, IItemRepository bookRepository) : base(unitOfWork, mapper)
        {
            _repository = bookRepository;
        }

        public async Task<List<ItemDAO>> Handle(GetAllItemRequest request, CancellationToken cancellationToken)
        {
            var result = _repository.GetAll();
            return _mapper.Map<List<ItemDAO>>(result);
        }
    }
}
