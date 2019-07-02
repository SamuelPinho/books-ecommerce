using Modelo.Infra;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Cadastros
{
    [Table("papeis")]
    public class Papel : IEntity
    {
        [Column("pap_id")]
        [Key, Required(ErrorMessage = "Todo papel tem um id")]
        public int Id { get; set; }

        [Column("pap_nome")]
        [Required(ErrorMessage = "Todo papel tem um nome")]
        [Display(Name = "Papel")]
        public string pap_nome { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}