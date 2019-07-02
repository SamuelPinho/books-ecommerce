using Microsoft.AspNetCore.Identity;
using Modelo;
using Modelo.Infra;
using Negocio.DAO;
using Negocio.DAO.Implementacao;
using System;

namespace Negocio.Strategy.Implementacao
{
    public class ValidarAcessoUsuario : IStrategy
    {
        private readonly DAOUsuario daoUsuario;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public ValidarAcessoUsuario(IDAO _daoUsuario,
            UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            daoUsuario = (DAOUsuario)_daoUsuario;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Processar(IEntity entity)
        {
            try
            {
                var usuarioDaController = (Usuario)entity;

                var senhaPassadaNaView = usuarioDaController.usr_senha;

                if (usuarioDaController.logar != null && (bool)usuarioDaController.logar)
                {
                    var usuario = _userManager.FindByEmailAsync(usuarioDaController.usr_email).Result;

                    if (usuario.usr_status != 1)
                    {
                        return "Seu usuário foi inativado, por favor entre em contato com a equipe de suporte";
                    }

                    usuario.usr_senha = _userManager.PasswordHasher.HashPassword(usuario, usuarioDaController.usr_senha);

                    _signInManager.PasswordSignInAsync(usuario, senhaPassadaNaView, (bool)usuarioDaController.lembrar_me,
                        lockoutOnFailure: false);

                    //if (!resultadoDoAcesso.Succeeded || resultadoDoAcesso.IsNotAllowed)
                    //{
                    //    return "Email ou senha inválidos";
                    //}
                }
                if (usuarioDaController.deslogar != null && (bool)usuarioDaController.deslogar)
                {
                    _signInManager.SignOutAsync();
                }

            }
            catch (Exception ex)
            {
                return "Ocorreu um erro interno: " + ex;
            }

            return null;
        }
    }
}
