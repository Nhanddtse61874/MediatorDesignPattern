using AutoMapper;
using MediatorAPI.ViewModel;
using MediatorDesignPatternLibrary.Model;
using MediatorHandler;
using MediatorHandler.Handler.OrderHandler;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorAPI.Controllers
{
    [ApiController]
    [Route("api-ordermanagement")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public OrderController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpGet("orders")]
        public IActionResult Index() => Ok(_mapper.Map<List<OrderViewModel>>(_mediator.Send(new GetAllOrderRequest { }).Result));


        [HttpDelete("order/{id}")]
        public async Task<IActionResult> Remove(int id) => Ok(await _mediator.Send(new RemoveOrderRequest { Id = id }));


        [HttpPost("order")]
        public async Task<IActionResult> Add(OrderViewModel order) => Ok(await _mediator.Send(new AddOrderRequest { Order = _mapper.Map<OrderDAO>(order) }));


        [HttpPut("order")]
        public async Task<IActionResult> Update(OrderViewModel order) => Ok(await _mediator.Send(new UpdateOrderRequest { Order = _mapper.Map<OrderDAO>(order) }));
    }
}
