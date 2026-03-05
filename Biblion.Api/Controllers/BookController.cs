using Biblion.Application.Interfaces;
using Biblion.Domain.entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(books);

        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            await _bookService.AddAsync(book);
            return Ok(book);
        }


    }
}
