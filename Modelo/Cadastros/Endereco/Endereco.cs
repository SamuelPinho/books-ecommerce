using Modelo.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Modelo.Cadastros
{
    [Table("enderecos")]
    public class Endereco : IEntity
    {

        [Column("end_id")]
        [Key]
        [Required(ErrorMessage = "Todo endereço tem um id")]
        public int Id { get; set; }

        [Column("end_cep")]
        [Required(ErrorMessage = "Todo endereço deve ter um CEP")]
        [Display(Name = "CEP")]
        public string cep { get; set; }

        [Column("end_logradouro")]
        [Required(ErrorMessage = "Todo endereço deve ter um logradouro")]
        [Display(Name = "Logradouro")]
        public string logradouro { get; set; }

        [Column("end_numero")]
        [Required(ErrorMessage = "Todo endereço deve ter um numero")]
        [Display(Name = "Número")]
        public int numero { get; set; }

        [Column("end_tipo_endereco")]
        [Required(ErrorMessage = "Todo endereço deve ter um tipo de endereço")]
        [Display(Name = "Tipo do Endereço")]
        public string tipoDeEndereco { get; set; }

        [Column("end_bairro")]
        [Required(ErrorMessage = "Todo endereço deve ter um bairro")]
        [Display(Name = "Bairro")]
        public string bairro { get; set; }

        [Column("end_cidade")]
        [Required(ErrorMessage = "Todo endereço deve ter uma cidade")]
        [Display(Name = "Cidade")]
        public string cidade { get; set; }

        [Column("end_observacoes")]
        [Display(Name = "Observações")]
        public string observacao { get; set; }

        [Column("end_apelido")]
        [Required(ErrorMessage = "Todo endereço deve ter um apelido")]
        [Display(Name = "Apelido")]
        [StringLength(40, ErrorMessage = "O apelido deve conter no máximo 40 caracteres")]
        public string apelido { get; set; }

        [Column("end_padrao")]
        [Required(ErrorMessage = "Todo endereço deve dizer se é o padrão")]
        [Display(Name = "Definir como padrão para próximas entregas?")]
        public bool ePadrao { get; set; }

        [Column("end_tipo_logradouro_id")]
        public int end_tipo_logradouro_id { get; set; }

        [ForeignKey("end_tipo_logradouro_id")]
        [Display(Name = "Tipo de Logradouro")]
        public TipoDeLogradouro TipoDeLogradouro { get; set; }

        [Column("end_estado_id")]
        public int end_estado_id { get; set; }

        [ForeignKey("end_estado_id")]
        [Display(Name = "Estado")]
        public Estado Estado { get; set; }

        [Column("end_pais_id")]
        public int end_pais_id { get; set; }

        [ForeignKey("end_pais_id")]
        [Display(Name = "País")]
        public Pais Pais { get; set; }

        public ICollection<Rel_Usuario_Endereco> EnderecosDoUsuario { get; set; }

    }
}
