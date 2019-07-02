using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Cadastros
{
    [Table("fornecedores")]
    public class Fornecedor : IEntity
    {
        [Key]
        [Display(Name = "Id")]
        [Column("for_id")]
        public int Id { get; set; }
        
        [Display(Name = "Nome do Fornecedor")]
        [Column("for_nome")]
        public string for_nome { get; set; }

        [Display(Name = "CNPJ do Fornecedor")]
        [Column("for_cnpj")]
        public string for_cnpj { get; set; }

        public ICollection<Rel_Livro_Fornecedor> FornecedoresDoLivro { get; set; }
    }
}
