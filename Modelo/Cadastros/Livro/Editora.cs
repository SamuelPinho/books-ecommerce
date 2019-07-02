using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Cadastros
{
    [Table("editoras")]
    public class Editora : IEntity
    {
        [Key]
        [Display(Name = "Id")]
        [Column("edi_id")]
        public int Id { get; set; }

        [Display(Name = "Nome da Editora")]
        [Column("edi_nome")]
        public string edi_nome { get; set; }

        public ICollection<Rel_Livro_Editora> EditorasDoLivro { get; set; }

    }
}
