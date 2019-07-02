using Modelo.Infra;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Cadastros
{
    [Table("hel_liv_cat")]
    public class Rel_Livro_Categoria
    {
        [Column("hlc_cat_id")]
        public int cat_id { get; set; }
        public Categoria Categoria { get; set; }

        [Column("hlc_liv_id")]
        public int Id { get; set; }
        public Livro Livro { get; set; }
    }

    [Table("hel_liv_aut")]
    public class Rel_Livro_Autor
    {
        [Column("hla_aut_id")]
        [Required]
        public int aut_id { get; set; }
        public Autor Autor { get; set; }

        [Column("hla_liv_id")]
        [Required]
        public int Id { get; set; }
        public Livro Livro { get; set; }

    }

    [Table("hel_liv_edi")]
    public class Rel_Livro_Editora
    {
        [Column("hle_edi_id")]
        public int edi_id { get; set; }
        public Editora Editora { get; set; }

        [Column("hle_liv_id")]
        public int Id { get; set; }
        public Livro Livro { get; set; }
    }

    [Table("hel_liv_for")]
    public class Rel_Livro_Fornecedor
    {
        [Column("hlf_for_id")]
        public int frn_id { get; set; }

        public Fornecedor Fornecedor { get; set; }

        [Column("hlf_liv_id")]
        public int Id { get; set; }

        public Livro Livro { get; set; }
    }

}
