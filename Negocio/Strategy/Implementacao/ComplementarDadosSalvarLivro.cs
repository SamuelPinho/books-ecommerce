using System;
using System.Collections.Generic;
using System.Text;
using Modelo;
using Modelo.Cadastros;

namespace Negocio.Strategy.Implementacao
{
    public class ComplementarDadosSalvarLivro : IStrategy
    {
        public string Processar(IEntity entity)
        {
            Livro livro = (Livro)entity;

            livro.liv_status = 1;
            livro.liv_data_inclusao = DateTime.UtcNow;
            livro.liv_data_ativacao = DateTime.UtcNow;

            return null;
        }
    }
}
