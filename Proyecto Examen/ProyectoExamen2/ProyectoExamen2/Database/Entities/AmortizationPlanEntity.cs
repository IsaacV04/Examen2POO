using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoExamen2.Database.Entities
{
    [Table("Amortization", Schema = "dbo")]
    public class AmortizationPlanEntity
    {
        public int Id { get; set; }
        public virtual LoanEntity Loan { get; set; }
        public int Days { get; set; }
        public decimal Interest { get; set; }
        public decimal SaldoDePrincipal { get; set; }
        public decimal PagoNiveladoSinSVSD { get; set; }
        public decimal PagoNiveladoConSVSD { get; set; }
        public DateTime PayDate { get; set; }
        public int NumeroCuota { get; set; }
        public decimal Principal { get; set; }
    }
}
