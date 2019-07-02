using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Cadastros
{
    [Table("status_pedido")]
    public class StatusPedido : IEntity
    {

        [Column("sta_ped_id")]
        [Key]
        public int Id { get; set; }

        [Column("sta_ped_descricao")]
        public string sta_ped_descricao { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }

    }
}