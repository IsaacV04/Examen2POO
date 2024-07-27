using ProyectoExamen2.Dto.Amortizations;

namespace ProyectoExamen2.Services.Interfaces
{
    public interface ILoanService
    {
        List<AmortizationDto> GenerarPlanAmortizacion(decimal monto, decimal tasaInteres, int plazo, decimal cuota);
    }
}
