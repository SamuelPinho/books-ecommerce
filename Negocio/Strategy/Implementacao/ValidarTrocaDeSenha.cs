using Microsoft.AspNetCore.Identity;
using Modelo;
using Modelo.Infra;
using Negocio.DAO;
using Negocio.DAO.Implementacao;
using System;

namespace Negocio.Strategy.Implementacao
{
    public class ValidarTrocaDeSenha : IStrategy
    {
        private readonly DAOUsuario daoUsuario;
        private readonly UserManager<Usuario> _userManager;

        public ValidarTrocaDeSenha(IDAO _daoUsuario, UserManager<Usuario> userManager)
        {
            daoUsuario = (DAOUsuario)_daoUsuario;
            _userManager = userManager;
        }

        public string Processar(IEntity entity)
        {
            var usuarioDaController = (Usuario)entity;

            var senhaAtual = usuarioDaController.usr_senha;

            if (usuarioDaController.senhaNovaDesejada != null)
            {
                try
                {
                    var usuario = _userManager.FindByEmailAsync(usuarioDaController.usr_email).Result;

                    usuario.usr_senha = _userManager.PasswordHasher.HashPassword(usuario, usuarioDaController.usr_senha);

                    var result = _userManager
                        .ChangePasswordAsync(usuario, senhaAtual, usuarioDaController.senhaNovaDesejada).Result;

                    if (!result.Succeeded)
                    {
                        return "A senha atual não está correta";
                    }
                }
                catch (Exception ex)
                {
                    return "Ocorreu um erro interno: " + ex;
                }
            }

            return null;
        }
    }
}
