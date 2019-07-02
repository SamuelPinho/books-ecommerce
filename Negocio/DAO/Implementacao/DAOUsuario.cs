using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.Cadastros;
using Modelo.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.DAO.Implementacao
{
    public class DAOUsuario : IDAO
    {
        private ECommerceDeLivrosContext _context;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public DAOUsuario(ECommerceDeLivrosContext context,
            UserManager<Usuario> userManager = null, SignInManager<Usuario> signInManager = null)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IEnumerable<IEntity> Consultar(IEntity entity)
        {
            Usuario usuario = (Usuario)entity;

            var usuarios = _context.Usuarios
                .Include(u => u.Papel)
                .Include(u => u.Genero)
                .Include(u => u.CuponsDoUsuario)
                    .ThenInclude(rel => rel.Cupom)
                .Include(u => u.CartoesDoUsuario)
                    .ThenInclude(rel => rel.Cartao)
                        .ThenInclude(car => car.Bandeira)
                .Include(u => u.EnderecosDoUsuario)
                    .ThenInclude(rel => rel.Endereco)
                        .ThenInclude(e => e.Pais)
                .Include(u => u.EnderecosDoUsuario)
                    .ThenInclude(rel => rel.Endereco)
                        .ThenInclude(e => e.Estado)
                .Include(u => u.EnderecosDoUsuario)
                    .ThenInclude(rel => rel.Endereco)
                        .ThenInclude(e => e.TipoDeLogradouro);

            // Se não possuir Id | retorna usuáios
            if (usuario.Id == 0)
            {
                // se tiver um email
                if (!string.IsNullOrEmpty(usuario.usr_email))
                {
                    return usuarios.Where(u => 
                        u.usr_email == usuario.usr_email).ToList();
                }
                return usuarios.ToList();
            }
            else
            {
                // Foi informado um Id para pesquisa
                return usuarios.Where(u => u.Id == usuario.Id).ToList();
            }
        }

        public IEntity Salvar(IEntity entity)
        {
            Usuario usuario = (Usuario) entity;

            var result = _userManager.CreateAsync(usuario, usuario.usr_senha).Result;

            if (result.Succeeded)
            {
                _signInManager.SignInAsync(usuario, false);
            }
            
            return usuario;
        }

        public IEntity Alterar(IEntity entity)
        {
            Usuario usuario = (Usuario)entity;

            _context.Update(usuario);

            _context.SaveChanges();

            return usuario;
        }

        public void Excluir(IEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
