using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Cadastros
{
    [Table("precificacoes")]
    public class Precificacao : IEntity
    {
        [Key]
        [Display(Name = "Id")]
        [Column("pre_id")]
        [Required]
        public int Id { get; set; }

        [Display(Name = "Porcentagem de Lucro")]
        [Column("pre_porcentagem")]
        [Required]
        public double pre_porcentagem { get; set; }

        [Display(Name = "Nome da Precificação")]
        [Column("pre_nome")]
        [Required]
        public string pre_nome { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}
