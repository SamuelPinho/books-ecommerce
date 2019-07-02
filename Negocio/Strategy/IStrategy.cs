using Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Strategy
{
    public interface IStrategy
    {
        string Processar(IEntity entity);
    }
}
