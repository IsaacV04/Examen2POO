using ProyectoExamen2.Dto.Amortizations;

namespace ProyectoExamen2.Dto.Loan
{
    public class LoanResponseDto
    {
        public string Message { get; set; }
        public List<AmortizationDto> AmortizationPlan { get; set; }
    }
}
