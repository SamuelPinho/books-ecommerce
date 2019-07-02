using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Modelo.Infra;

namespace Modelo.Cadastros
{
    [Table("generos")]
    public class Genero : IEntity
    {
        [Key, Required, Column("gen_id")]
        [Display(Name = "Id do genero")]
        public int Id { get; set; }

        [Required, Column("gen_nome")]
        [Display(Name = "Genero")]
        public string gen_nome { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}
