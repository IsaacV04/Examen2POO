using ProyectoExamen2.Dto.Amortizations;
using ProyectoExamen2.Services.Interfaces;

namespace ProyectoExamen2.Services
{
    public class LoanService : ILoanService
    {
        public decimal CalcularCuota(decimal monto, decimal tasaInteres, int plazo)
        {
            var tasaMensual = tasaInteres / 100 / 12;
            var cuota = monto * (tasaMensual * (decimal)Math.Pow(1 + (double)tasaMensual, plazo)) / ((decimal)Math.Pow(1 + (double)tasaMensual, plazo) - 1);
            return cuota;
        }

        public List<AmortizationDto> GenerarPlanAmortizacion(decimal monto, decimal tasaInteres, int plazo, decimal cuota)
        {
            var prestamoList = new List<AmortizationDto>();
            var saldo = monto;

            for (int mes = 1; mes <= plazo; mes++)
            {
                var interes = saldo * (tasaInteres / 100 / 12);
                var amortization = cuota - interes;
                saldo -= amortization;

                prestamoList.Add(new AmortizationDto 
                {
                    Month = mes,
                    Pay = cuota,
                    Interest = interes,
                    Amortization = amortization,
                    Balance = saldo
                });
            }

            return prestamoList;
        }
    }
}
