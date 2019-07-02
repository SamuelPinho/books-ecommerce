using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.DAO.Implementacao
{
    public class DAOStatusPedido : IDAO
    {
        private ECommerceDeLivrosContext _context;

        public DAOStatusPedido(ECommerceDeLivrosContext context)
        {
            _context = context;
        }

        public IEntity Alterar(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEntity> Consultar(IEntity entity)
        {
            StatusPedido statusPedido = (StatusPedido) entity;

            // faz um select no banco de dados
            var listaStatus = _context.StatusPedido;

            // Se foi passado um Id | retorna uma lista de entidades
            if (statusPedido.Id == 0)
            {
                // Se não foi passada uma descrição da entidade | retorna todas as entidades
                if (statusPedido.sta_ped_descricao == null)
                {
                    return listaStatus.ToList();
                }

                // Se foi passada uma descrição da entidade | retorna todas as entidades com a descrição
                return listaStatus.Where(l => l.sta_ped_descricao == statusPedido.sta_ped_descricao).ToList();
            }
            else
            {
                // Se foi passado um Id | retorna a entidade especificada
                return listaStatus.Where(l => l.Id == statusPedido.Id).ToList();
            }
        }

        public void Excluir(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEntity Salvar(IEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
