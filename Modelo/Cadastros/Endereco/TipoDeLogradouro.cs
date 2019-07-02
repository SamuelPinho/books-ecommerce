using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Cadastros
{
    [Table("tipos_de_logradouro")]
    public class TipoDeLogradouro : IEntity
    {
        
        [Column("tip_id")]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("tip_nome")]
        [Required]
        public string nome { get; set; }

        public ICollection<Endereco> Enderecos { get; set; }

    }
}