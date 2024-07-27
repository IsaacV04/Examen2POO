namespace ProyectoExamen2.Dto.Loan
{
    public class LoanDto
    {
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public int Term { get; set; }
        public DateTime DisbursementDate { get; set; }
        public DateTime FirstPaymentData { get; set; }
        public decimal MonthlyPayment { get; set; }
    }
}
