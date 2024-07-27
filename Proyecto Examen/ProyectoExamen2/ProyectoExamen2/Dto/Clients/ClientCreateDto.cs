using ProyectoExamen2.Database.Entities;

namespace ProyectoExamen2.Dto.Clients
{
    public class ClientCreateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string IdentityNumber { get; set; }

        public virtual ICollection<LoanEntity> Loan { get; set; }
    }
}
