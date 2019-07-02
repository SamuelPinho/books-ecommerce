using Modelo.Cadastros;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Infra
{
    [Table("usuarios")]
    public class Usuario : IEntity
    {
        [Column("usr_id")]
        [Key, Required]
        [Display(Name = "Id do usuário")]
        public int Id { get; set; }

        [Column("usr_primeiro_nome")]
        [Required(ErrorMessage = "Todo usuário possui um nome"), StringLength(35)]
        [Display(Name = "Nome do usuário")]
        public string usr_primeiro_nome { get; set; }

        [Column("usr_sobrenome")]
        [Required(ErrorMessage = "Todo usuário possui um sobrenome"), StringLength(35)]
        [Display(Name = "Sobrenome")]
        public string usr_sobrenome { get; set; }

        [Column("usr_email")]
        [Required(ErrorMessage = "Todo usuário possui um e-mail"), MaxLength(35)]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido")]
        [Display(Name = "E-mail do usuário")]
        public string usr_email { get; set; }

        [Column("usr_senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha do usuário")]
        public string usr_senha { get; set; }

        [Column("usr_cpf")]
        [Required(ErrorMessage = "Todo usuário possui um CPF")]
        [Display(Name = "CPF do usuário")]
        public string usr_cpf { get; set; }

        [Column("usr_data_nascimento")]
        [Required(ErrorMessage = "Todo usuário possui uma data de nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name = "Data de Nascimento do usuário")]
        public DateTime usr_data_nascimento { get; set; }

        [Column("usr_status")]
        [Required(ErrorMessage = "Todo usuário possui um status")]
        [Display(Name = "Status do usuário")]
        public int usr_status { get; set; }

        [Column("usr_ranking")]
        [Display(Name = "Ranking do usuário")]
        public int usr_ranking { get; set; }

        [Column("usr_genero_id")]
        [Required(ErrorMessage = "Todo usuário possui um gênero")]
        [Display(Name = "Gênero do usuário")]
        public int usr_genero_id { get; set; }

        [ForeignKey("usr_genero_id")]
        public Genero Genero { get; set; }

        [Column("usr_papel_id")]
        [Required(ErrorMessage = "Todo usuário possui um papel")]
        [Display(Name = "Papel do usuário")]
        public int usr_papel_id { get; set; }

        [NotMapped]
        public bool ?lembrar_me { get; set; }

        [NotMapped]
        public bool ?logar { get; set; }

        [NotMapped]
        public bool ?deslogar { get; set; }

        [NotMapped]
        public string senhaNovaDesejada { get; set; }

        [ForeignKey("usr_papel_id")]
        public Papel Papel { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }

        [Display(Name = "Cupons")]
        public ICollection<Rel_Usuario_Cupom> CuponsDoUsuario { get; set; }

        [Display(Name = "Cartões")]
        public ICollection<Rel_Usuario_Cartao> CartoesDoUsuario { get; set; }

        [Display(Name = "Endereços")]
        public ICollection<Rel_Usuario_Endereco> EnderecosDoUsuario { get; set; }

        [Display(Name = "Telefones")]
        public ICollection<Rel_Usuario_Telefone> TelefonesDoUsuario { get; set; }

    }
}
