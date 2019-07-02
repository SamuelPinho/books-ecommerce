using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Cadastros
{
    [Table("paises")]
    public class Pais : IEntity
    {

        [Column("pai_id")]
        [Key]
        public int Id { get; set; }

        [Column("pai_nome")]
        [Required]
        [Display(Name = "País")]
        public string pai_nome { get; set; }

        public ICollection<Endereco> Enderecos { get; set; }

    }
}