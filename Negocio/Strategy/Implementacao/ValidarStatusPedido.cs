using Modelo;
using Modelo.Cadastros;
using Negocio.DAO.Implementacao;
using Negocio.Strategy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Negocio.Strategy.Implementacao
{
    public class ValidarStatusPedido : IStrategy
    {
        public string Processar(IEntity entity)
        {
            Pedido pedido = (Pedido)entity;

            // Se nenhum status é passado | retorna uma mensagem de erro
            if (pedido.ped_status_id == 0)
            {
                return "Nenhum status foi passado para cadastro<br>";
            }

            // Foi passado um status | retorna Ok
            return null;
        }
    }
}
