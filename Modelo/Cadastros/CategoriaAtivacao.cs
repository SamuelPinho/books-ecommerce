using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Cadastros
{
    [Table("categorias_ativacao")]
    public class CategoriaAtivacao : IEntity
    {
        [Key]
        [Column("cata_id")]
        public int Id { get; set; }

        [Column("cata_descricao")]
        public string cata_descricao { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}
