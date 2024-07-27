using Microsoft.EntityFrameworkCore;
using ProyectoExamen2.Database;
using ProyectoExamen2.Database.Entities;
using ProyectoExamen2.Dto.Amortizations;
using ProyectoExamen2.Dto.Loan;
using ProyectoExamen2.Services.Interfaces;
using System;

namespace ProyectoExamen2.Services
{
    public class LoanService : ILoanService
    {
        private readonly ProyectoExamenContext _context;

        public LoanService(ProyectoExamenContext context)
        {
            _context = context;
        }

        public decimal CalcularCuotaNivelada(decimal amount, decimal intrestRate, int term)
        {
            // Implementar la fórmula para calcular la cuota nivelada  
            decimal monthlyRate = intrestRate / 100 / 12;
            decimal cuota = (amount * monthlyRate) / (1 - (decimal)Math.Pow(1 + (double)monthlyRate, -term));
            return cuota;
        }

        public async Task<LoanResponseDto> CreateLoanAsync(LoanCreateDto loanCreateDto)
        {
            // Crear cliente y préstamo  
            var cliente = new ClienteEntity
            {
                Name = loanCreateDto.Name,
                IdentityNumber = loanCreateDto.IdentityNumber
            };

            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();

            var loan = new LoanEntity
            {
                Amount = loanCreateDto.Amount,
                InterestRate = loanCreateDto.InterestRate,
                Term = loanCreateDto.Term,
                DisbursementDate = loanCreateDto.DisbursementDate,
                FirstPaymentData = loanCreateDto.FirstPaymentData,
                Cliente = cliente
            };

            // Calcular la cuota nivelada y generar el plan de amortización  
            List<AmortizationDto> amortizationPlan = new List<AmortizationDto>();
            decimal saldo = loan.Amount; 
            decimal monthlyRate = loan.InterestRate / 100 / 12;  
            decimal cuota = CalcularCuotaNivelada(loan.Amount, loan.InterestRate, loan.Term);
            for (int i = 1; i <= loan.Term; i++)
            {
                // Calcular el interés de la cuota  
                decimal interest = saldo * monthlyRate;
                // Calcular el principal de la cuota  
                decimal principal = cuota - interest;
                // Actualizar el saldo restante  
                saldo -= principal;

                // Crear el objeto de amortización y agregar a la lista  
                amortizationPlan.Add(new AmortizationDto
                {
                    NumeroCuota = i,
                    PayDate = loan.FirstPaymentData.AddMonths(i),  
                    Interest = interest,
                    Principal = principal,
                    PagoNiveladoSinSVSD = cuota, 
                    PagoNiveladoConSVSD = cuota,  
                    SaldoDePrincipal = saldo >= 0 ? saldo : 0 
                });
            }

            loan.Amortizations = amortizationPlan.Select(a => new AmortizationPlanEntity
            {
                NumeroCuota = a.NumeroCuota,
                PayDate = a.PayDate,
                Interest = a.Interest,
                Principal = a.Principal,
                PagoNiveladoSinSVSD = a.PagoNiveladoSinSVSD,
                PagoNiveladoConSVSD = a.PagoNiveladoConSVSD,
                SaldoDePrincipal = a.SaldoDePrincipal
            }).ToList();

            _context.Loan.Add(loan);
            await _context.SaveChangesAsync();

            return new LoanResponseDto
            {
                Message = "Loan and amortization plan successfully created.",
                AmortizationPlan = amortizationPlan
            };
        }

        public async Task<LoanDetailsDto> GetPayPlansByClientAsync(Guid clientId)
        {
            var cliente = await _context.Cliente
                .Include(c => c.Loan)
                    .ThenInclude(p => p.Amortizations)
                .FirstOrDefaultAsync(c => c.Id == clientId);

            if (cliente == null)
            {
                return null; // Manejar error  
            }

            var prestamoDto = new LoanDetailsDto
            {
                ClientId = cliente.Id,
                Name = cliente.Name,
                IdentityNumber = cliente.IdentityNumber,
                Amount = cliente.Loan.FirstOrDefault()?.Amount ?? 0,
                AmortizationPlan = cliente.Loan.SelectMany(p => p.Amortizations.Select(a => new AmortizationDto
                {
                    NumeroCuota = a.NumeroCuota,
                    PayDate = a.PayDate,
                    Days = a.Days,
                    Interest = a.Interest,
                    Principal = a.Principal,
                    PagoNiveladoSinSVSD = a.PagoNiveladoSinSVSD,
                    PagoNiveladoConSVSD = a.PagoNiveladoConSVSD,
                    SaldoDePrincipal = a.SaldoDePrincipal
                })).ToList()
            };

            return prestamoDto;
        }

        
    }
}
