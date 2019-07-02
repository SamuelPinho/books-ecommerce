using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Cadastros
{
    [Table("assuntos")]
    public class Assunto : IEntity
    {
        [Key]
        [Column("ass_id")]
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [Column("ass_descricao")]
        public string ass_descricao { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}
