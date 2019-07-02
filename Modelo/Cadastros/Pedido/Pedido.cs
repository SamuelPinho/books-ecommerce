using Modelo.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Cadastros
{
    [Table("pedidos")]
    public class Pedido : IEntity
    {

        [Column("ped_id")]
        [Key, Required]
        public int Id { get; set; }

        [Column("ped_data")]
        [Required(ErrorMessage = "Todo pedido precisa de uma data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name = "Data do pedido")]
        public DateTime ped_data { get; set; }

        [Column("ped_status_id")]
        [Required]
        public int ped_status_id { get; set; }

        [ForeignKey("ped_status_id")]
        public StatusPedido StatusPedido { get; set; }

        [Column("ped_usuario_id")]
        [Required]
        public int ped_usuario_id { get; set; }

        [ForeignKey("ped_usuario_id")]
        public Usuario Usuario { get; set; }

        [Column("ped_endereco_id")]
        public int? ped_endereco_id { get; set; }

        [ForeignKey("ped_endereco_id")]
        public Endereco Endereco { get; set; }

        public ICollection<Rel_Pedido_Livro> LivrosDoPedido { get; set; }
        public ICollection<Rel_Pedido_Cartao> CartoesDoPedido { get; set; }
        public ICollection<Rel_Pedido_Cupom> CuponsDoPedido { get; set; }

        [NotMapped]
        public ICollection<Rel_Pedido_Livro> LivrosDoPedidoParaAlterar { get; set; }

        [NotMapped]
        public bool ?alterarLivros { get; set; }

    }
}
