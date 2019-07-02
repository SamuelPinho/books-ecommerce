using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Cadastros
{
    [Table("categorias_inativacao")]
    public class CategoriaInativacao : IEntity
    {
        [Key]
        [Column("cati_id")]
        public int Id { get; set; }

        [Column("cati_descricao")]
        public string cati_descricao { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}
