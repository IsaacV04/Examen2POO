using ProyectoExamen2.Dto.Amortizations;
using ProyectoExamen2.Dto.Loan;

namespace ProyectoExamen2.Services.Interfaces
{
    public interface ILoanService
    {
        Task<LoanResponseDto> CreateLoanAsync(LoanCreateDto loanCreateDto);
        Task<LoanDetailsDto> GetPayPlansByClientAsync(Guid clientId);
    }
}
