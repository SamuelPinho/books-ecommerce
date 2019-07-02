using Modelo;
using Modelo.Infra;
using Negocio.DAO;
using Negocio.DAO.Implementacao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Negocio.Strategy.Implementacao
{
    public class ValidarExistenciaUsuario : IStrategy
    {
        private readonly DAOUsuario daoUsuario;
        private readonly string _comando;

        public ValidarExistenciaUsuario(IDAO _daoUsuario, string comando = "consultar")
        {
            daoUsuario = (DAOUsuario) _daoUsuario;
            _comando = comando;
        }

        public string Processar(IEntity entity)
        {
            try
            {
                var usuarios = (IList<Usuario>)daoUsuario.Consultar(entity);

                // Se a busca não retornou resultados | retorna mensagem de erro
                if (_comando == "salvar")
                {
                    if (usuarios.Count() != 0)
                    {
                        return "Já há um usuário cadastrado com este e-mail";
                    }
                }
                else // se o comando era para salvar e retornou algo verifica se o objetivo é salvar
                {
                    if (usuarios.Count() == 0)
                    {
                        return "E-mail ou senha inválidos";
                    }
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
