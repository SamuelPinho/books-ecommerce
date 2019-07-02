using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Cadastros
{
    [Table("bandeiras_cartoes")]
    public class Bandeira : IEntity
    {

        [Column("ban_id")]
        [Required]
        [Key]
        public int Id { get; set; }

        [Column("ban_nome")]
        [Required]
        [Display(Name = "Bandeira")]
        public string ban_nome { get; set; }

    }
}