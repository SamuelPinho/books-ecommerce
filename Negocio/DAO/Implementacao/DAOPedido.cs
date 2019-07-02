using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.DAO.Implementacao
{
    public class DAOPedido : IDAO
    {
        private ECommerceDeLivrosContext _context;

        public DAOPedido(ECommerceDeLivrosContext context)
        {
            _context = context;
        }

        public IEnumerable<IEntity> Consultar(IEntity entity)
        {
            Pedido pedido = (Pedido)entity;

            var pedidos = _context.Pedidos
                .Include(p => p.StatusPedido)
                .Include(p => p.Endereco)
                    .ThenInclude(e => e.Estado)
                .Include(p => p.Endereco)
                    .ThenInclude(e => e.Pais)
                .Include(p => p.Endereco)
                    .ThenInclude(e => e.TipoDeLogradouro)
                .Include(p => p.CartoesDoPedido)
                    .ThenInclude(rel => rel.Cartao)
                        .ThenInclude(car => car.Bandeira)
                .Include(p => p.CuponsDoPedido)
                    .ThenInclude(rel => rel.Cupom)
                .Include(p => p.LivrosDoPedido)
                    .ThenInclude(rel => rel.Livro)
                        .ThenInclude(l => l.AutoresDoLivro)
                            .ThenInclude(rel => rel.Autor);

            // Se não possuir Id | retorna pedidos
            if (pedido.Id == 0)
            {
                // Se foi passado o id de um usuário | verifica apenas os pedidos deles
                if (pedido.ped_usuario_id != 0)
                {
                    var pedidosUsuario = pedidos.Where(p => p.ped_usuario_id == pedido.ped_usuario_id);

                    // Se não foi passado o status desejado | retorna todos os pedidos do usuário
                    if (pedido.StatusPedido == null && pedido.ped_status_id == 0)
                    {
                        return pedidosUsuario.ToList();
                    }

                    // Se possui o status do pedido | retorna todos os pedidos do usuário
                    //  que correspondem ao status passado
                    return pedidosUsuario
                        .Where(p => p.StatusPedido.sta_ped_descricao == pedido.StatusPedido.sta_ped_descricao ||
                                    p.ped_status_id == pedido.ped_status_id)
                        .ToList();
                }
                
                // Se não foi passado o status desejado | retorna todos os pedidos de todos os usuário
                if (pedido.StatusPedido == null && pedido.ped_status_id == 0)
                {
                    return pedidos.ToList();
                }

                // Se possui o status do pedido | retorna todos os pedidos de todos os usuários
                //  que correspondem ao status passado
                return pedidos
                        .Where(p => p.StatusPedido.sta_ped_descricao == pedido.StatusPedido.sta_ped_descricao ||
                                    p.ped_status_id == pedido.ped_status_id)
                        .ToList();
            }
            else
            {
                // Foi informado um Id para pesquisa
                return pedidos.Where(p => p.Id == pedido.Id).ToList();
            }
        }

        public IEntity Salvar(IEntity entity)
        {
            Pedido pedido = (Pedido) entity;

            _context.Add(pedido);

            _context.SaveChanges();

            return pedido;
        }

        public IEntity Alterar(IEntity entity)
        {
            Pedido pedido = (Pedido) entity;

            _context.Update(pedido);

            _context.SaveChanges();

            return pedido;
        }

        public void Excluir(IEntity entity)
        {
            var pedido = (Pedido) entity;

            if(pedido.CartoesDoPedido != null)
            {
                _context.Rel_Pedido_Cartao.RemoveRange(pedido.CartoesDoPedido);
            }
            if(pedido.CuponsDoPedido != null)
            {
                _context.Rel_Pedido_Cupom.RemoveRange(pedido.CuponsDoPedido);
            }
            //_context.Rel_Pedido_Livro.RemoveRange(pedido.LivrosDoPedido);

            _context.Pedidos.Remove(pedido);

            _context.SaveChanges();
        }
    }
}
