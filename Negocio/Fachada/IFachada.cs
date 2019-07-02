using Modelo;
using Negocio.Aplicacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Fachada
{
    public interface IFachada
    {
        Resultado Consultar(IEntity entity);
        Resultado Salvar(IEntity entity);
        Resultado Alterar(IEntity entity);
        Resultado Excluir(IEntity entity);

    }
}
