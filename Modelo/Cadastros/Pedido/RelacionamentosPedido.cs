using Modelo.Cadastros;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Cadastros
{
    [Table("hel_ped_liv")]
    public class Rel_Pedido_Livro : IEntity
    {
        [Column("hpl_ped_id")]
        public int ped_id { get; set; }
        public Pedido Pedido { get; set; }

        [Column("hpl_liv_id")]
        public int Id { get; set; }
        public Livro Livro { get; set; }

        [Column("hpl_quantidade")]
        public int hpl_quantidade { get; set; }

        [Column("hpl_valor")]
        public double hpl_valor { get; set; }

        [Column("hpl_preco_total")]
        public double hpl_preco_total { get; set; }

        [Column("hpl_valor_frete")]
        public double hpl_valor_frete { get; set; }

        [Column("hpl_trocado")]
        public bool hpl_trocado { get; set; }

    }

    [Table("hel_ped_cup")]
    public class Rel_Pedido_Cupom
    {
        [Column("hpcu_ped_id")]
        [Required]
        public int ped_id { get; set; }
        public Pedido Pedido { get; set; }

        [Column("hpcu_cup_id")]
        [Required]
        public int cup_id { get; set; }
        public Cupom Cupom { get; set; }

    }

    [Table("hel_ped_car")]
    public class Rel_Pedido_Cartao
    {
        [Column("hpca_ped_id")]
        [Required]
        public int ped_id { get; set; }
        public Pedido Pedido { get; set; }

        [Column("hpca_car_id")]
        [Required]
        public int car_id { get; set; }
        public Cartao Cartao { get; set; }

    }

}
