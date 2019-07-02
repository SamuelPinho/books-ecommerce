using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Cadastros
{
    [Table("categorias")]
    public class Categoria : IEntity
    {
        [Key]
        [Display(Name = "Id")]
        [Column("cat_id")]
        public int Id { get; set; }

        [Display(Name = "Nome da Categoria")]
        [Column("cat_nome")]
        public string cat_nome { get; set; }

        public ICollection<Rel_Livro_Categoria> CategoriasDoLivro { get; set; }

    }
}
