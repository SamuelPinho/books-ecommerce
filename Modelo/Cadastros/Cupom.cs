using Modelo.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Modelo.Cadastros
{
    [Table("cupons")]
    public class Cupom : IEntity
    {
        [Column("cup_id")]
        [Key]
        [Required(ErrorMessage = "Todo cupom tem um Id")]
        public int Id { get; set; }

        [Column("cup_cod")]
        [Required(ErrorMessage = "Todo cupom tem um código de identificação")]
        [Display(Name = "Identificação")]
        public string codigo { get; set; }

        [Column("cup_data_inclusao")]
        [Required(ErrorMessage = "Todo cupom deve ter uma data de inclusão")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data de Inclusão")]
        public DateTime dataDeInclusao { get; set; }

        [Column("cup_data_utilizado")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data de Utilização")]
        public DateTime dataDeUtilizacao { get; set; }

        [Column("cup_ativo")]
        [Required]
        [Display(Name = "Ativo?")]
        public bool ativo { get; set; }

        [Column("cup_valor")]
        [Required(ErrorMessage = "Todo cupom deve ter um valor")]
        [Display(Name = "Valor")]
        public double valor { get; set; }

        [Column("cup_troca")]
        [Required(ErrorMessage = "Todo cupom deve dizer se é de troca ou não")]
        [Display(Name = "É de Troca?")]
        public bool eDeTroca { get; set; }

        public ICollection<Rel_Usuario_Cupom> CuponsDoUsuario { get; set; }

        public ICollection<Rel_Pedido_Cupom> CuponsDoPedido { get; set; }

    }
}
