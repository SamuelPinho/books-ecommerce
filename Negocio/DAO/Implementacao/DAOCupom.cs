using Modelo;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Negocio.DAO.Implementacao
{
    public class DAOCupom : IDAO
    {
        private ECommerceDeLivrosContext _context;

        public DAOCupom(ECommerceDeLivrosContext context)
        {
            _context = context;
        }

        public IEntity Alterar(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEntity> Consultar(IEntity entity)
        {
            Cupom cupom = (Cupom)entity;

            // faz um select no banco de dados
            var cupons = _context.Cupons;

            // Se foi passado um Id | retorna uma lista de entidades
            if (cupom.Id == 0)
            {
                // Se não foi passada uma descrição da entidade | retorna todas as entidades
                if (cupom.codigo == null)
                {
                    return cupons.ToList();
                }

                // Se foi passada uma descrição da entidade | retorna todas as entidades com a descrição
                return cupons.Where(l => l.codigo == cupom.codigo).ToList();
            }
            else
            {
                // Se foi passado um Id | retorna a entidade especificada
                return cupons.Where(l => l.Id == cupom.Id).ToList();
            }
        }

        public void Excluir(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEntity Salvar(IEntity entity)
        {
            Cupom cupom = (Cupom)entity;

            _context.Add(cupom);

            _context.SaveChanges();

            return cupom;
        }
    }
}
