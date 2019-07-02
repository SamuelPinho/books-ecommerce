using Modelo.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Modelo.Cadastros
{
    [Table("cartoes")]
    public class Cartao : IEntity
    {

        [Column("car_id")]
        [Key]
        [Required(ErrorMessage = "Todo cartão deve ter um id")]
        public int Id { get; set; }

        [Column("car_numero")]
        [Required(ErrorMessage = "Todo cartão deve ter um número")]
        [Display(Name = "Número")]
        [DataType(DataType.CreditCard)]
        public string car_numero { get; set; }

        [Column("car_cod_seguranca")]
        [Required(ErrorMessage = "Todo cartão deve ter um código de segurança")]
        [Display(Name = "Código de Segurança")]
        [StringLength(3, ErrorMessage = "O CVV deve ter 3 caracteres", MinimumLength = 3)]
        public string car_cod_seguranca { get; set; }

        [Column("car_data_validade")]
        [Required(ErrorMessage = "Todo cartão deve mter uma data de validade")]
        [Display(Name = "Data de Validade")]
        [DisplayFormat(DataFormatString = "{0:MM-yy}")]
        [DataType(DataType.Date)]
        public DateTime car_data_validade { get; set; }

        [Column("car_data_inclusao")]
        [Required(ErrorMessage = "Todo cartão deve ter uma data de inclusão")]
        [Display(Name = "Data de Inclusão")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime car_data_inclusao { get; set; }

        [Column("car_titular")]
        [Required(ErrorMessage = "Todo cartão deve ter um titular")]
        [Display(Name = "Nome do Titular")]
        public string car_titular { get; set; }

        [Column("car_status")]
        [Required(ErrorMessage = "Todo cartão deve ter um status")]
        [Display(Name ="Status do cartão")]
        public int car_status { get; set; }

        [Column("car_padrao")]
        [Required(ErrorMessage = "Todo cartão deve dizer se é padrão ou não")]
        [Display(Name = "Definir como padrão para próximas compras?")]
        public bool ePadrao { get; set; }

        [Column("car_bandeira_id")]
        [Display(Name = "Bandeira")]
        public int car_bandeira_id { get; set; }

        [ForeignKey("car_bandeira_id")]
        public Bandeira Bandeira { get; set; }

        public ICollection<Rel_Usuario_Cartao> CartoesDoUsuario { get; set; }

        public ICollection<Rel_Pedido_Cartao> CartoesDoPedido { get; set; }

    }
}
