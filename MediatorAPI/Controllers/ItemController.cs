using AutoMapper;
using MediatorAPI.ViewModel;
using MediatorDesignPatternLibrary.Model;
using MediatorHandler.Handler.ItemHandler;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorAPI.Controllers
{
    [ApiController]
    [Route("api/item-management")]
    public class ItemController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ItemController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("items")]
        public IActionResult Index() => Ok(_mapper.Map<List<ItemViewModel>>(_mediator.Send(new GetAllItemRequest { }).Result));


        [HttpDelete("item/{id}")]
        public async Task<IActionResult> Remove(int id) => Ok(await _mediator.Send(new RemoveItemRequest { Id = id }));


        [HttpPost("item")]
        public async Task<IActionResult> Add(ItemViewModel item) => Ok(await _mediator.Send(new AddItemRequest { Item = _mapper.Map<ItemDAO>(item) }));


        [HttpPut("item")]
        public async Task<IActionResult> Update(ItemViewModel item) => Ok(await _mediator.Send(new UpdateItemRequest { Item = _mapper.Map<ItemDAO>(item) }));
    }
}
