using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Negocio.DAO.Implementacao
{
    public class DAOCartao : IDAO
    {
        private ECommerceDeLivrosContext _context;

        public DAOCartao(ECommerceDeLivrosContext context)
        {
            _context = context;
        }

        public IEnumerable<IEntity> Consultar(IEntity entity)
        {
            Cartao cartão = (Cartao)entity;

            // Se não possuir Id | retorna livros
            if (cartão.Id == 0)
            {
                var cartoes = _context.Cartoes
                    .Include(c => c.Bandeira)
                    .Include(c => c.CartoesDoUsuario)
                        .ThenInclude(rel => rel.Usuario)
                    .Include(c => c.CartoesDoPedido)
                        .ThenInclude(rel => rel.Pedido)
                            .ThenInclude(p => p.StatusPedido);

                // Se não possui titulo do livro | retorna todos os livros
                if (cartão.car_numero == null)
                {
                    return cartoes.ToList();
                }

                // Se possui o titulo do livro | retorna todos os livros que correspondem à ele
                return cartoes.Where(c => c.car_numero == cartão.car_numero).ToList();
            }
            else
            {
                // Foi informado um Id para pesquisa
                return _context.Cartoes
                    .Include(c => c.Bandeira)
                    .Include(c => c.CartoesDoUsuario)
                        .ThenInclude(rel => rel.Usuario)
                    .Include(c => c.CartoesDoPedido)
                        .ThenInclude(rel => rel.Pedido)
                            .ThenInclude(p => p.StatusPedido);
            }
        }

        public IEntity Salvar(IEntity entity)
        {
            Cartao cartao = (Cartao) entity;

            _context.Add(cartao);

            _context.SaveChanges();

            return cartao;
        }

        public IEntity Alterar(IEntity entity)
        {
            Cartao cartao = (Cartao) entity;

            _context.Update(cartao);

            _context.SaveChanges();

            return cartao;
        }

        public void Excluir(IEntity entity)
        {
            Cartao cartao = (Cartao)entity;

            _context.Remove(cartao);

            _context.SaveChanges();
        }
    }
}
