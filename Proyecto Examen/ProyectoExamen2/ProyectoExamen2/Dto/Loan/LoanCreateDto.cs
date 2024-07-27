namespace ProyectoExamen2.Dto.Loan
{
    public class LoanCreateDto
    {
        public string Name { get; set; }
        public string IdentityNumber { get; set; }
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public int Term { get; set; }
        public DateTime DisbursementDate { get; set; }
        public DateTime FirstPaymentData { get; set; }

    }
}
