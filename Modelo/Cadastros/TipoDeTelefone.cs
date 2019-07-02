using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Cadastros
{
    [Table("tipos_de_telefone")]
    public class TipoDeTelefone
    {

        [Column("tip_id")]
        [Key]
        public int Id { get; set; }

        [Column("tip_nome")]
        public string tip_nome { get; set; }

    }
}