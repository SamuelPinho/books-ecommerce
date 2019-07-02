using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Modelo.Infra
{
    [Table("hel_usr_cup")]
    public class Rel_Usuario_Cupom
    {
        [Column("hucu_usr_id")]
        public int relUsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        [Column("hucu_cup_id")]
        public int relCupomId { get; set; }

        public Cupom Cupom { get; set; }
    }

    [Table("hel_usr_car")]
    public class Rel_Usuario_Cartao
    {
        [Column("huca_usr_id")]
        public int relUsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        [Column("huca_car_id")]
        public int relCartaoId { get; set; }

        public Cartao Cartao { get; set; }
    }

    [Table("hel_usr_end")]
    public class Rel_Usuario_Endereco
    {
        [Column("hue_usr_id")]
        public int relUsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        [Column("hue_end_id")]
        public int relEnderecoId { get; set; }

        public Endereco Endereco { get; set; }
    }

    [Table("hel_usr_tel")]
    public class Rel_Usuario_Telefone
    {
        [Column("hut_usr_id")]
        public int relUsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        [Column("hut_tel_id")]
        public int relTelefoneId { get; set; }

        public Telefone Telefone { get; set; }
    }
}
