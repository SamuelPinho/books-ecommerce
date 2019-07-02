using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Cadastros
{
    [Table("estados")]
    public class Estado : IEntity
    {

        [Column("est_id")]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("est_sigla")]
        [Required]
        [Display(Name = "Estado")]
        public string est_sigla { get; set; }

        public ICollection<Endereco> Enderecos { get; set; }

    }
}