using Biblion.Application.Dtos.Loans;
using Biblion.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {

        private readonly ILoanService _loanService;
        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLoan([FromBody] LoansDto dto)
        {
            if (dto.User == null || dto.User.Id == Guid.Empty)
                return BadRequest("Se requiere un usuario válido");

            
            if (dto.LoanDate == default)
                dto.LoanDate = DateTime.Now;

            await _loanService.AddAsync(dto);

           
            return Ok(new
            {
                Usuario = dto.User.Name,
                LoanDate = dto.LoanDate,
                ReturnDate = dto.LoanDate.AddDays(7)
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var loans = await _loanService.GetAllAsync();
            return Ok(loans);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var loans = await _loanService.GetByUserIdAsync(id);
            if (loans == null || loans.Count == 0)
                return NotFound();
            return Ok(loans);
        }

        [HttpGet("date/{fecha}")]
        public async Task<IActionResult> GetByDate(DateTime fecha)
        {
            var loans = await _loanService.GetByDateAsync(fecha);
            return Ok(loans);
        }

    }
}
