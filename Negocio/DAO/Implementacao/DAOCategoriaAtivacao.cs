using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.DAO.Implementacao
{
    public class DAOCategoriaAtivacao : IDAO
    {
        private ECommerceDeLivrosContext _context;

        public DAOCategoriaAtivacao(ECommerceDeLivrosContext context)
        {
            _context = context;
        }

        public IEntity Alterar(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEntity> Consultar(IEntity entity)
        {
            CategoriaAtivacao categoriaAtivacao = (CategoriaAtivacao)entity;

            // faz um select no banco de dados
            var categorias = _context.Categorias_Ativacao;

            // Se foi passado um Id | retorna uma lista de categorias
            if (categoriaAtivacao.Id == 0)
            {
                // Se não foi passada uma descrição da categoria | retorna todas as categorias
                if (categoriaAtivacao.cata_descricao == null)
                {
                    return categorias.ToList();
                }

                // Se foi passada uma descrição da categoria | retorna todas as categorias com a descrição
                return categorias.Where(l => l.cata_descricao == categoriaAtivacao.cata_descricao).ToList();
            }
            else
            {
                // Se foi passado um Id | retorna a categoria especificada
                return categorias.Where(l => l.Id == categoriaAtivacao.Id).ToList();
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
