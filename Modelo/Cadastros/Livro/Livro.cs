using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Cadastros
{
    [Table("livros")]
    public class Livro : IEntity
    {
        [Key]
        [Display(Name = "Id")]
        [Column("liv_id")]
        public int Id { get; set; }

        [Display(Name = "Titulo")]
        [Column("liv_titulo")]
        [Required(ErrorMessage = "Todo livro precisa de um titulo")]
        public string liv_titulo { get; set; }

        [Display(Name = "ISBN")]
        [Column("liv_isbn")]
        [Required(ErrorMessage = "Todo livro precisa de um ISBN")]
        [MinLength(13, ErrorMessage = "O ISBN precisa ter 13 dígitos")]
        [MaxLength(13, ErrorMessage = "O ISBN só poder ter 13 dígitos")]
        public string liv_isbn { get; set; }

        [Display(Name = "Sinopse")]
        [Column("liv_sinopse")]
        [Required(ErrorMessage = "Todo livro conta uma história")]
        public string liv_sinopse { get; set; }

        [Display(Name = "Altura")]
        [Column("liv_altura")]
        public string liv_altura { get; set; }

        [Display(Name = "Largura")]
        [Column("liv_largura")]
        public string liv_largura { get; set; }

        [Display(Name = "Profundidade")]
        [Column("liv_profundidade")]
        public string liv_profundidade { get; set; }

        [Display(Name = "Custo")]
        [Column("liv_custo")]
        public double liv_custo { get; set; }

        [Display(Name = "Descrição da Inativação")]
        [Column("liv_descricao_inativacao")]
        public string liv_descricao_inativacao { get; set; }

        [Display(Name = "Descrição da Ativação")]
        [Column("liv_descricao_ativacao")]
        public string liv_descricao_ativacao { get; set; }

        [Display(Name = "Valor de Venda")]
        [Column("liv_valor_venda")]
        public double liv_valor_venda { get; set; }

        [Display(Name = "Valor de Venda Temporário")]
        [Column("liv_valor_venda_temp")]
        public double liv_valor_venda_temp { get; set; }

        [Display(Name = "Imagem da Capa")]
        [Column("liv_imagemcapa")]
        public string liv_imagemcapa { get; set; }

        [Display(Name = "Ativo?")]
        [Column("liv_status")]
        public int liv_status { get; set; }

        [Display(Name = "Edição")]
        [Column("liv_edicao")]
        [Required(ErrorMessage = "Todo livro tem uma edição")]
        public int liv_edicao { get; set; }

        [Display(Name = "Número de Páginas")]
        [Column("liv_paginas")]
        [Required(ErrorMessage = "Todo livro tem um número de páginas")]
        public int liv_paginas { get; set; }

        [Display(Name = "Quantidade")]
        [Column("liv_quantidade")]
        public int liv_quantidade { get; set; }

        [Display(Name = "Data da Inativação")]
        [Column("liv_data_inativacao")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime liv_data_inativacao { get; set; }

        [Display(Name = "Data de Ativação")]
        [Column("liv_data_ativacao")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? liv_data_ativacao { get; set; }

        [Display(Name = "Data da Publicação")]
        [Column("liv_data_publicacao")]
        [Required(ErrorMessage = "Todo livro tem uma data de publicação")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime liv_data_publicacao { get; set; }

        [Display(Name = "Data da Inclusão")]
        [Column("liv_data_inclusao")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime liv_data_inclusao { get; set; }

        [Display(Name = "Data de Entrada em Estoque")]
        [Column("liv_data_entrada_estoque")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime liv_data_entrada_estoque { get; set; }

        [Display(Name = "Código de Barras")]
        [Column("liv_codigo_barra")]
        [Required(ErrorMessage = "Todo livro tem um código de barras")]
        [MinLength(13, ErrorMessage = "O código de barras precisa ter 13 digitos")]
        [MaxLength(13, ErrorMessage = "O código de barras só poder ter 13 dígitos")]
        public string liv_codigo_barra { get; set; }

        // Colunas de FK ------------------------------------------

        [Display(Name = "Categoria de Precificação")]
        [Column("liv_precificacao_id")]
        [Required(ErrorMessage = "Todo livro precisa ter uma categoria de precificação")]
        public int liv_precificacao_id { get; set; }

        [ForeignKey("liv_precificacao_id")]
        public Precificacao Precificacao { get; set; }

        [Display(Name = "Categoria de Ativação")]
        [Column("liv_categoria_ativacao")]
        public int? liv_categoria_ativacao { get; set; }

        [ForeignKey("liv_categoria_ativacao")]
        public CategoriaAtivacao CategoriaAtivacao { get; set; }

        [Display(Name = "Categoria de Inativação")]
        [Column("liv_categoria_inativacao")]
        public int? liv_categoria_inativacao { get; set; }

        [ForeignKey("liv_categoria_inativacao")]
        public CategoriaInativacao CategoriaInativacao { get; set; }

        [Display(Name = "Assunto")]
        [Column("liv_assunto_id")]
        [Required(ErrorMessage = "Todo livro precisa de um assunto")]
        public int liv_assunto_id { get; set; }

        [ForeignKey("liv_assunto_id")]
        [Display(Name = "Assunto")]
        public Assunto Assunto { get; set; }

        // Objetos para as tabelas de relacionamento
        
        [Display(Name = "Fornecedores")]
        public ICollection<Rel_Livro_Fornecedor> Fornecedores { get; set; }

        [Display(Name = "Autores")]
        public IList<Rel_Livro_Autor> AutoresDoLivro { get; set; }

        [Display(Name = "Categorias")]
        public ICollection<Rel_Livro_Categoria> CategoriasDoLivro { get; set; }

        [Display(Name = "Editoras")]
        public ICollection<Rel_Livro_Editora> EditorasDoLivro { get; set; }

        public ICollection<Rel_Pedido_Livro> LivrosDoPedido { get; set; }
    }

}
