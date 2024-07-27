namespace ProyectoExamen2.Dto.Amortizations
{
    public class AmortizationDto
    {
        public int Month { get; set; }
        public decimal Pay { get; set; }
        public decimal Interest { get; set; }
        public decimal Amortization { get; set; }
        public decimal Balance { get; set; }
    }
}
