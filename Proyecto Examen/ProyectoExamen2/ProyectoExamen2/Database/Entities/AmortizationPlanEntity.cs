using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoExamen2.Database.Entities
{
    [Table("Amortization", Schema = "dbo")]
    public class AmortizationPlanEntity
    {
        public int Id { get; set; }
        public int LoanId { get; set; }
        public int Month { get; set; }
        public decimal Pay { get; set; }
        public decimal Interest { get; set; }
        public decimal Amortization { get; set; }
        public decimal Balance { get; set; }
}
}
