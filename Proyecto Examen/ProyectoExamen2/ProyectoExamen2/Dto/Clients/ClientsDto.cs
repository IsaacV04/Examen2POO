using ProyectoExamen2.Database.Entities;

namespace ProyectoExamen2.Dto.Clients
{
    public class ClientsDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }

        public string IdentityNumber { get; set; }

        public virtual ICollection<LoanEntity> Loan { get; set; }
    }
}
