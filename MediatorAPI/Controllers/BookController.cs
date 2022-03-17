using AutoMapper;
using MediatorAPI.ViewModel;
using MediatorDesignPatternLibrary.Model;
using MediatorHandler.Handler.BookHandler;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorAPI.Controllers
{
    [ApiController]
    [Route("api/book-management")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public BookController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("books")]
        public IActionResult Index() => Ok(_mapper.Map<List<BookViewModel>>(_mediator.Send(new GetAllBookRequest { }).Result));
        
            
        [HttpDelete("book/{id}")]
        public async Task<IActionResult> Remove(int id) => Ok(await _mediator.Send(new RemoveBookRequest{Id = id }));


        [HttpPost("book")]
        public async Task<IActionResult> Add(CreatedBookViewModel book) => Ok(await _mediator.Send(new AddBookRequest { Book = _mapper.Map<BookDAO>(book)}));


        [HttpPut("book")]
        public async Task<IActionResult> Update(BookViewModel book) => Ok(await _mediator.Send(new UpdateBookRequest { Book = _mapper.Map<BookDAO>(book) }));

    }
}
