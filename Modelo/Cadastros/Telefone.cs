using Modelo.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Modelo.Cadastros
{
    [Table("telefones")]
    public class Telefone
    {
        [Column("tel_id")]
        [Key, Required]
        public int Id { get; set; }

        [Column("tel_numero")]
        [Required]
        [Display(Name = "Número")]
        public int numero { get; set; }

        [Column("tel_cod_area")]
        [Required]
        [Display(Name = "Código de Área")]
        public int codArea { get; set; }

        [Column("tel_padrao")]
        [Required]
        [Display(Name = "É padrão?")]
        public int ePadrao { get; set; }

        [Column("tel_tipo_id")]
        public int tipoId { get; set; }

        [ForeignKey("tipoId")]
        public TipoDeTelefone TipoDeTelefone { get; set; }

        public ICollection<Rel_Usuario_Telefone> TelefonesDoUsuario { get; set; }

    }
}
