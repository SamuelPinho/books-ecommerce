using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Modelo;
using Modelo.Cadastros;
using Modelo.Infra;
using Negocio.Aplicacao;
using Negocio.DAO;
using Negocio.Factory.Implementacao;
using Negocio.Strategy;
using Negocio.Strategy.Implementacao;

namespace Negocio.Fachada
{
    public class Fachada : IFachada
    {
        // 1 string - Class Name que identifica a qual entidade as regras pertencem
        // 2 string - operacao a ser executada
        // List<IStrategy> - uma lista contendo todas as regras de negócio
        // Dictionary<ClassName, Dictionary<operacao, listaDeRegras>>
        private Dictionary<string, Dictionary<string, List<IStrategy>>> regrasDeNegocio;
        private readonly FactoryDAO _factoryDAO;
        private readonly UserManager<Usuario> userManager;
        private readonly SignInManager<Usuario> signInManager;

        public Fachada(FactoryDAO factoryDAO, UserManager<Usuario> _userManager, SignInManager<Usuario> _signInManager)
        {
            _factoryDAO = factoryDAO;
            userManager = _userManager;
            signInManager = _signInManager;

            // Regras de Negócio
            regrasDeNegocio = new Dictionary<string, Dictionary<string, List<IStrategy>>>();

            // ----------------------------------------------------------------------------------------------
            // Livro

            Dictionary<string, List<IStrategy>> regrasDeNegocioLivro = new Dictionary<string, List<IStrategy>>();

            
            // adição das strsategies especificas para salvar o livro
            List<IStrategy> listaRegrasDeNegocioSalvarLivro = new List<IStrategy>()
            {
                new ValidarExistenciaLivroSalvar(_factoryDAO.Factory("Livro")),
                new ComplementarDadosSalvarLivro()
            };

            // adição das strategies especificas para alterar o livro
            List<IStrategy> listaRegrasDeNegocioAlterarLivro = new List<IStrategy>()
            {
                new ValidarPrecoVenda(
                    _factoryDAO.Factory("Livro"), _factoryDAO.Factory("CategoriaInativacao"), _factoryDAO.Factory("Precificacao"))
            };

            // adição das strategies especificas para consultar o livro
            List<IStrategy> listaRegrasDeNegocioConsultarLivro = new List<IStrategy>()
            {
                new ValidarExistenciaLivroConsultar(_factoryDAO.Factory("Livro"))
            };

            // Adicionar as regras ao Dict de livro
            regrasDeNegocioLivro["salvar"] = listaRegrasDeNegocioSalvarLivro;
            regrasDeNegocioLivro["alterar"] = listaRegrasDeNegocioAlterarLivro;
            regrasDeNegocioLivro["consultar"] = listaRegrasDeNegocioConsultarLivro;

            // Adiciona as regras de negócio do livro às regras gerais
            regrasDeNegocio[nameof(Livro)] = regrasDeNegocioLivro;

            // Final Livro
            // ----------------------------------------------------------------------------------------------
            // Pedido

            Dictionary<string, List<IStrategy>> regrasDeNegocioPedido = new Dictionary<string, List<IStrategy>>();

            // Definição das listas de regras de negócio do pedido
            // adição das strategies especificas para salvar o pedido
            List<IStrategy> listaRegrasDeNegocioSalvarPedido = new List<IStrategy>()
            {
                new ValidarExistenciaLivroPedido(_factoryDAO.Factory("Livro")),
                new ValidarExistenciaStatusPedido(_factoryDAO.Factory("StatusPedido")),
                new DarBaixaEstoque(_factoryDAO.Factory("Pedido")),
                new CalcularValorTotalItensCarrinho(),
                new CalcularValorFreteCarrinho(),
                new ComplementarDadosSalvarPedido()
            };

            // adição das strategies especificas para alterar o pedido
            List<IStrategy> listaRegrasDeNegocioAlterarPedido = new List<IStrategy>()
            {
                new ValidarExistenciaLivroPedido(_factoryDAO.Factory("Livro")),
                new ValidarExistenciaStatusPedido(_factoryDAO.Factory("StatusPedido")),
                new DarBaixaEstoque(_factoryDAO.Factory("Pedido")),
                new AlterarItensCarrinho(_factoryDAO.Factory("Pedido")),
                new CalcularValorTotalItensCarrinho(),
                new CalcularValorFreteCarrinho()
            };

            // adição das strategies especificas para excluir o pedido
            List<IStrategy> listaRegrasDeNegocioExcluirPedido = new List<IStrategy>()
            {
                new ValidarExistenciaLivroPedido(_factoryDAO.Factory("Livro")),
                new ValidarExistenciaStatusPedido(_factoryDAO.Factory("StatusPedido")),
                new ExclusaoQuantidades(_factoryDAO.Factory("Pedido"), _factoryDAO.Factory("Livro"))
            };

            // Adicionar as regras ao Dict de pedido
            regrasDeNegocioPedido["salvar"] = listaRegrasDeNegocioSalvarPedido;
            regrasDeNegocioPedido["alterar"] = listaRegrasDeNegocioAlterarPedido;
            regrasDeNegocioPedido["excluir"] = listaRegrasDeNegocioExcluirPedido;

            // Adiciona as regras de negócio do pedido às regras gerais
            regrasDeNegocio[nameof(Pedido)] = regrasDeNegocioPedido;

            // Final Pedido
            // ----------------------------------------------------------------------------------------------
            // Status do Pedido

            Dictionary<string, List<IStrategy>> regrasDeNegocioStatusPedido = new Dictionary<string, List<IStrategy>>();

            // adição das strategies especificas para salvar o pedido
            List<IStrategy> listaRegrasDeNegocioConsultarStatusPedido = new List<IStrategy>
            {
                new ValidarExistenciaStatusPedidoConsultar(_factoryDAO.Factory("StatusPedido"))
            };

            // adição das strategies especificas para alterar o pedido

            // Adicionar as regras ao Dict de pedido
            regrasDeNegocioStatusPedido["consultar"] = listaRegrasDeNegocioConsultarStatusPedido;

            // Adiciona as regras de negócio do pedido às regras gerais
            regrasDeNegocio[nameof(Pedido)] = regrasDeNegocioPedido;

            // ----------------------------------------------------------------------------------------------
            // ----------------------------------------------------------------------------------------------
            // ------------- Usuario

            Dictionary<string, List<IStrategy>> regrasDeNegocioUsuario = new Dictionary<string, List<IStrategy>>();

            // adição das strategies especificas para consutar o usuário
            List<IStrategy> listaRegrasDeNegocioConsultarUsuario = new List<IStrategy>
            {
                new ValidarExistenciaUsuario(_factoryDAO.Factory("Usuario")),
            };

            List<IStrategy> listaRegrasDeNegocioSalvarUsuario = new List<IStrategy>
            {
                new ValidarExistenciaUsuario(_factoryDAO.Factory("Usuario"), "salvar"),
            };

            List<IStrategy> listaRegrasDeNegocioAlterarUsuario = new List<IStrategy>
            {
                new ValidarAcessoUsuario(_factoryDAO.Factory("Usuario"), userManager, signInManager),
                new ValidarTrocaDeSenha(_factoryDAO.Factory("Usuario"), userManager)
            };

            // Adicionar as regras ao Dict de usuáio
            regrasDeNegocioUsuario["consultar"] = listaRegrasDeNegocioConsultarUsuario;
            regrasDeNegocioUsuario["salvar"] = listaRegrasDeNegocioSalvarUsuario;
            regrasDeNegocioUsuario["alterar"] = listaRegrasDeNegocioAlterarUsuario;

            // Adiciona as regras de negócio do pedido às regras gerais
            regrasDeNegocio[nameof(Usuario)] = regrasDeNegocioUsuario;

            // Final Usuario
            // ----------------------------------------------------------------------------------------------

        } // Final do construtor da Fachada

        // métodos publicos da Fachada ----------------------------------------------------------------------

        public Resultado Alterar(IEntity entity)
        {
            string msg = ExecutarRegras(entity, "alterar");

            Resultado resultado = new Resultado();

            if (msg == null)
            {
                IDAO dao = _factoryDAO.Factory(entity.GetType().Name);

                try
                {
                    resultado.Entidades = new IEntity[] { dao.Alterar(entity) };
                }
                catch (Exception ex)
                {
                    msg = "Ocorreu um erro interno: " + ex;
                }
            }

            resultado.MensagensDeErro = msg;

            return resultado;
        }

        public Resultado Consultar(IEntity entity)
        {
            string msg = ExecutarRegras(entity, "consultar");

            Resultado resultado = new Resultado();

            if (msg == null)
            {

                try
                {
                    IDAO dao = _factoryDAO.Factory(entity.GetType().Name);
                    resultado.Entidades = dao.Consultar(entity);
                }
                catch (Exception ex)
                {
                    msg = "Ocorreu um erro interno: " + ex;
                }
            }

            resultado.MensagensDeErro = msg;

            return resultado;
        }

        public Resultado Excluir(IEntity entity)
        {
            String msg = ExecutarRegras(entity, "excluir");

            Resultado resultado = new Resultado();

            if (msg == null)
            {
                IDAO dao = _factoryDAO.Factory(entity.GetType().Name);

                try
                {
                    dao.Excluir(entity);
                    resultado.Entidades = new IEntity[] { entity };
                }
                catch (Exception ex)
                {
                    msg = "Ocorreu um erro interno: " + ex;
                }
            }

            resultado.MensagensDeErro = msg;

            return resultado;
        }

        public Resultado Salvar(IEntity entity)
        {
            String msg = ExecutarRegras(entity, "salvar");

            Resultado resultado = new Resultado();

            if (msg == null)
            {
                IDAO dao = _factoryDAO.Factory(entity.GetType().Name);

                try
                {
                    resultado.Entidades = new IEntity[] { dao.Salvar(entity) };
                }
                catch (Exception ex)
                {
                    msg = "Ocorreu um erro interno: " + ex;
                }
            }

            resultado.MensagensDeErro = msg;

            return resultado;
        }

        // Responsavel por executar o método processar das strategy definidas pela lista de regrasDeNegocio
        private string ExecutarRegras(IEntity entity, string operacao)
        {
            string msg = "";

            // define chave como sendo o nome da classe invocada por entity
            string chave = entity.GetType().Name;

            //Dictionary<string, List<IStrategy>> regrasDeNegocioDaEntidade = regrasDeNegocio[chave];

            // se regrasDeNegocio[chave] for diferente de null | executa 
            if (regrasDeNegocio.TryGetValue(chave, out Dictionary<string, List<IStrategy>> regrasDeNegocioDaEntidade))
            {
                // Se regrasDeNegocioDaEntidade[operacao] for diferente de null | executa a lista de strategies
                if (regrasDeNegocioDaEntidade.TryGetValue(operacao, out List<IStrategy> regras))
                {
                    // para cada strategy na lista de regras
                    foreach (var strategy in regras)
                    {
                        // executa o método Processar da strategy que retorna as mensagens de erro
                        string mensagem = strategy.Processar(entity);
                        if (mensagem != null)
                        {
                            msg += mensagem;

                            return msg;
                        }
                    }
                }
            }

            // se não houver mensagem de erro | retorna null
            if (string.IsNullOrEmpty(msg))
            {
                return null;
            }
            // se houver mensagem de erro | retorna a mensagem
            else
            {
                return msg;
            }
        }
    }
}
