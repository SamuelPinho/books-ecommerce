using Microsoft.EntityFrameworkCore;
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
    public class ValidarExistenciaStatusPedido : IStrategy
    {
        private readonly DAOStatusPedido daoStatusPedido;

        public ValidarExistenciaStatusPedido(IDAO _daoStatusPedido)
        {
            daoStatusPedido = (DAOStatusPedido)_daoStatusPedido;
        }

        public string Processar(IEntity entity)
        {
            Pedido pedido = (Pedido)entity;

            var status = new StatusPedido();

            if(pedido.ped_status_id != 0)
            {
                status.Id = pedido.ped_status_id;

                status = (StatusPedido)daoStatusPedido.Consultar(status).FirstOrDefault();
            }
            else
            {
                status = (StatusPedido)daoStatusPedido.Consultar(pedido.StatusPedido).FirstOrDefault();
            }

            // verifica se retorna um Status
            if (status == null)
            {
                return "Este status não existe.";
            }

            pedido.StatusPedido = status;
            pedido.ped_status_id = status.Id;

            return null;
        }

    }
}
