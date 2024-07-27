using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoExamen2.Database.Entities
{
    [Table("Loan", Schema = "dbo")]
    public class LoanEntity
    {
        public int Id { get; set; }
        public virtual ClienteEntity Cliente { get; set; }
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public int Term { get; set; }
        public DateTime DisbursementDate { get; set; }
        public DateTime FirstPaymentData { get; set; }
        public virtual ICollection<AmortizationPlanEntity> Amortizations { get; set; }
    }
}
