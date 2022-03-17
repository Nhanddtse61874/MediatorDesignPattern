using AutoMapper;
using DataAccessLayer.Repository;

namespace MediatorHandler
{
    public class HandlerBase
    {
        protected readonly IUnitOfWork _unitOfWork;

        protected readonly IMapper _mapper;
        public HandlerBase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
