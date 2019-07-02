using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Cadastros
{
    [Table("autores")]
    public class Autor : IEntity
    {
        [Key]
        [Display(Name = "Id")]
        [Column("aut_id")]
        [Required]
        public int Id { get; set; }

        [Display(Name = "Nome do Autor")]
        [Column("aut_nome")]
        [Required]
        public string aut_nome { get; set; }

        public ICollection<Rel_Livro_Autor> AutoresDoLivro { get; set; }

    }
}
