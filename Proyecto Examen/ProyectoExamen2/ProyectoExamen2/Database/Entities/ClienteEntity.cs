using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoExamen2.Database.Entities
{
    [Table("clients", Schema = "dbo")]
    public class ClienteEntity
    {

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} del cliente es requerido.")]
        [StringLength(10)]
        [Column("name")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "El {0} del cliente es requerido")]
        [Column ("id")]
        public Guid Id { get; set; }

        [Column("identity_number")]
        public string IdentityNumber { get; set; }
        public virtual ICollection<LoanEntity> Loan { get; set; }
    }
}

