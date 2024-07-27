using ProyectoExamen2.Dto.Amortizations;

namespace ProyectoExamen2.Dto.Loan
{
    public class LoanDetailsDto
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string IdentityNumber { get; set; }
        public decimal Amount { get; set; }
        public List<AmortizationDto> AmortizationPlan { get; set; }
    }
}
