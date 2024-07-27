namespace ProyectoExamen2.Dto.Amortizations
{
    public class AmortizationDto
    {
        public int NumeroCuota { get; set; }
        public DateTime PayDate { get; set; }
        public int Days { get; set; }
        public decimal Interest { get; set; }
        public decimal Principal { get; set; }
        public decimal PagoNiveladoSinSVSD { get; set; }
        public decimal PagoNiveladoConSVSD { get; set; }
        public decimal SaldoDePrincipal { get; set; }
    }
}
