using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;
using Modelo.Infra;

namespace Negocio
{
    public class ECommerceDeLivrosContext : DbContext
    {
        public ECommerceDeLivrosContext(DbContextOptions<ECommerceDeLivrosContext> options) 
            : base(options) { }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Assunto> Assuntos { get; set; }
        public DbSet<Precificacao> Precificacoes { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Cartao> OpcoesPagamento { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cupom> Cupons { get; set; }
        public DbSet<TipoDeLogradouro> TipoDeLogradouro { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<TipoDeTelefone> TipoDeTelefones { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Bandeira> Bandeiras { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<StatusPedido> StatusPedido { get; set; }
        public DbSet<CategoriaAtivacao> Categorias_Ativacao { get; set; }
        public DbSet<CategoriaInativacao> Categorias_Inativacaos { get; set; }
        public DbSet<Rel_Livro_Autor> Rel_Livros_Autores { get; set; }
        public DbSet<Rel_Livro_Categoria> Rel_Livros_Categorias { get; set; }
        public DbSet<Rel_Livro_Editora> Rel_Livros_Editoras { get; set; }
        public DbSet<Rel_Livro_Fornecedor> Rel_Livros_Fornecedores { get; set; }
        public DbSet<Rel_Usuario_Cartao> Rel_Usuario_Cartao { get; set; }
        public DbSet<Rel_Usuario_Cupom> Rel_Usuario_Cupom { get; set; }
        public DbSet<Rel_Usuario_Endereco> Rel_Usuario_Endereco { get; set; }
        public DbSet<Rel_Usuario_Telefone> Rel_Usuario_Telefone { get; set; }
        public DbSet<Rel_Pedido_Cartao> Rel_Pedido_Cartao { get; set; }
        public DbSet<Rel_Pedido_Cupom> Rel_Pedido_Cupom { get; set; }
        public DbSet<Rel_Pedido_Livro> Rel_Pedido_Livro { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Papel> Papeis { get; set; }
        public DbSet<Genero> Generos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Rel_Livro_Categoria>()
                .HasKey(lc => new { lc.cat_id, lc.Id });

            modelBuilder.Entity<Rel_Livro_Categoria>()
                .HasOne(lc => lc.Livro)
                .WithMany(lc => lc.CategoriasDoLivro)
                .HasForeignKey(lc => lc.Id);

            modelBuilder.Entity<Rel_Livro_Categoria>()
                .HasOne(lc => lc.Categoria)
                .WithMany(lc => lc.CategoriasDoLivro)
                .HasForeignKey(lc => lc.cat_id);

            modelBuilder.Entity<Rel_Livro_Autor>()
                .HasKey(la => new { la.aut_id, la.Id });

            modelBuilder.Entity<Rel_Livro_Autor>()
                .HasOne(la => la.Livro)
                .WithMany(la => la.AutoresDoLivro)
                .HasForeignKey(la => la.Id);

            modelBuilder.Entity<Rel_Livro_Autor>()
                .HasOne(la => la.Autor)
                .WithMany(la => la.AutoresDoLivro)
                .HasForeignKey(la => la.aut_id);

            modelBuilder.Entity<Rel_Livro_Editora>()
                .HasKey(le => new { le.edi_id, le.Id });

            modelBuilder.Entity<Rel_Livro_Editora>()
                .HasOne(le => le.Livro)
                .WithMany(lc => lc.EditorasDoLivro)
                .HasForeignKey(lc => lc.Id);

            modelBuilder.Entity<Rel_Livro_Editora>()
                .HasOne(le => le.Editora)
                .WithMany(le => le.EditorasDoLivro)
                .HasForeignKey(le => le.edi_id);

            modelBuilder.Entity<Rel_Usuario_Cartao>()
                .HasKey(le => new { le.relCartaoId, le.relUsuarioId });

            modelBuilder.Entity<Rel_Usuario_Cartao>()
                .HasOne(le => le.Usuario)
                .WithMany(lc => lc.CartoesDoUsuario)
                .HasForeignKey(lc => lc.relUsuarioId);

            modelBuilder.Entity<Rel_Usuario_Cartao>()
                .HasOne(le => le.Cartao)
                .WithMany(le => le.CartoesDoUsuario)
                .HasForeignKey(le => le.relCartaoId);


            modelBuilder.Entity<Rel_Usuario_Cupom>()
                .HasKey(le => new { le.relCupomId, le.relUsuarioId });

            modelBuilder.Entity<Rel_Usuario_Cupom>()
                .HasOne(le => le.Usuario)
                .WithMany(lc => lc.CuponsDoUsuario)
                .HasForeignKey(lc => lc.relUsuarioId);

            modelBuilder.Entity<Rel_Usuario_Cupom>()
                .HasOne(le => le.Cupom)
                .WithMany(le => le.CuponsDoUsuario)
                .HasForeignKey(le => le.relCupomId);


            modelBuilder.Entity<Rel_Usuario_Endereco>()
                .HasKey(le => new { le.relEnderecoId, le.relUsuarioId });

            modelBuilder.Entity<Rel_Usuario_Endereco>()
                .HasOne(le => le.Usuario)
                .WithMany(lc => lc.EnderecosDoUsuario)
                .HasForeignKey(lc => lc.relUsuarioId);

            modelBuilder.Entity<Rel_Usuario_Endereco>()
                .HasOne(le => le.Endereco)
                .WithMany(le => le.EnderecosDoUsuario)
                .HasForeignKey(le => le.relEnderecoId);


            modelBuilder.Entity<Rel_Usuario_Telefone>()
                .HasKey(le => new { le.relTelefoneId, le.relUsuarioId });

            modelBuilder.Entity<Rel_Usuario_Telefone>()
                .HasOne(le => le.Usuario)
                .WithMany(lc => lc.TelefonesDoUsuario)
                .HasForeignKey(lc => lc.relUsuarioId);

            modelBuilder.Entity<Rel_Usuario_Telefone>()
                .HasOne(le => le.Telefone)
                .WithMany(le => le.TelefonesDoUsuario)
                .HasForeignKey(le => le.relTelefoneId);


            modelBuilder.Entity<Rel_Livro_Fornecedor>()
                .HasKey(le => new { le.frn_id, le.Id });

            modelBuilder.Entity<Rel_Livro_Fornecedor>()
                .HasOne(le => le.Livro)
                .WithMany(lc => lc.Fornecedores)
                .HasForeignKey(lc => lc.Id);

            modelBuilder.Entity<Rel_Livro_Fornecedor>()
                .HasOne(le => le.Fornecedor)
                .WithMany(le => le.FornecedoresDoLivro)
                .HasForeignKey(le => le.frn_id);


            modelBuilder.Entity<Rel_Pedido_Livro>()
                .HasKey(le => new { le.ped_id, le.Id });

            modelBuilder.Entity<Rel_Pedido_Livro>()
                .HasOne(le => le.Pedido)
                .WithMany(lc => lc.LivrosDoPedido)
                .HasForeignKey(lc => lc.ped_id);

            modelBuilder.Entity<Rel_Pedido_Livro>()
                .HasOne(le => le.Livro)
                .WithMany(le => le.LivrosDoPedido)
                .HasForeignKey(le => le.Id);


            modelBuilder.Entity<Rel_Pedido_Cartao>()
                .HasKey(le => new { le.ped_id, le.car_id });

            modelBuilder.Entity<Rel_Pedido_Cartao>()
                .HasOne(le => le.Pedido)
                .WithMany(lc => lc.CartoesDoPedido)
                .HasForeignKey(lc => lc.ped_id);

            modelBuilder.Entity<Rel_Pedido_Cartao>()
                .HasOne(le => le.Cartao)
                .WithMany(le => le.CartoesDoPedido)
                .HasForeignKey(le => le.car_id);


            modelBuilder.Entity<Rel_Pedido_Cupom>()
                .HasKey(le => new { le.ped_id, le.cup_id });

            modelBuilder.Entity<Rel_Pedido_Cupom>()
                .HasOne(le => le.Pedido)
                .WithMany(lc => lc.CuponsDoPedido)
                .HasForeignKey(lc => lc.ped_id);

            modelBuilder.Entity<Rel_Pedido_Cupom>()
                .HasOne(le => le.Cupom)
                .WithMany(le => le.CuponsDoPedido)
                .HasForeignKey(le => le.cup_id);
        }


    }
}
