using Modelo;
using Modelo.Cadastros;
using Negocio.DAO;
using Negocio.DAO.Implementacao;
using Negocio.Strategy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Negocio.Strategy.Implementacao
{
    public class ValidarExistenciaStatusPedidoConsultar : IStrategy
    {
        private readonly DAOStatusPedido daoStatusPedido;

        public ValidarExistenciaStatusPedidoConsultar(IDAO _daoStatusPedido)
        {
            daoStatusPedido = (DAOStatusPedido)_daoStatusPedido;
        }

        public string Processar(IEntity entity)
        {
            StatusPedido statusPedido = (StatusPedido) entity;

            // Verifica se a busca possui um status
            try
            {
                var listaStatus = (IList<StatusPedido>) daoStatusPedido.Consultar(statusPedido);

                if (listaStatus.Count() == 0) {
                    return "O status procurado não existe<br>";
                }
            }
            catch (Exception)
            {
                return "Ocorreu um erro interno";
            }

            return null;
        }
    }
}
