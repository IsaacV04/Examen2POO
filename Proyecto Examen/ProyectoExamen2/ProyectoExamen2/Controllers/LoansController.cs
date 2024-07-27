using Microsoft.AspNetCore.Mvc;
using ProyectoExamen2.Dto.Loan;
using ProyectoExamen2.Services.Interfaces;

namespace ProyectoExamen2.Controllers
{
    [ApiController]
    [Route("api/loans")]
    public class LoansController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoansController(ILoanService prestamoService)
        {
            _loanService = prestamoService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearPrestamo([FromBody] LoanCreateDto crearPrestamoDto)
        {
            var response = await _loanService.CreateLoanAsync(crearPrestamoDto);
            return Ok(response);
        }

        [HttpGet("{clientId}")]
        public async Task<IActionResult> ObtenerPlanPagoPorCliente(Guid clientId)
        {
            var plan = await _loanService.GetPayPlansByClientAsync(clientId);
            if (plan == null)
            {
                return NotFound();
            }
            return Ok(plan);
        }
    }
}
