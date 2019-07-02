using System.IO;
using Microsoft.Extensions.Configuration;
using Xunit;
using Selenium.Utils;
using System;

namespace ECommerceDeLivros.Testes
{
    public class TestesHome
    {
        private IConfiguration _configuration;

        public TestesHome()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json");

            _configuration = builder.Build();
        }

        [Theory]
        [InlineData(Browser.Chrome, "teste", "Resultado da Busca")]
        [InlineData(Browser.Chrome, "", "Os Mais Vendidos")]
        [InlineData(Browser.Chrome, "Douglas Adams", "Resultado da Busca")]
        [InlineData(Browser.Chrome, "1223", "Sua busca não retornou resultados :(")]
        public void TestarBusca(Browser browser, string textoBusca, string resultadoBusca)
        {
            TelaHome tela = new TelaHome(_configuration, browser);

            tela.CarregarPagina();
            tela.PreencherBusca(textoBusca);
            tela.ProcessarBusca();

            string resultado = tela.ObterTexto("resultadoBusca");
            tela.Fechar();

            Assert.Equal(resultadoBusca, resultado);
            
        }

        [Theory]
        [InlineData(Browser.Chrome, "msn.dosamuel@gmail.com", "@Placo2019", "msn.dosamuel@gmail.com")]
        public void TestarLogin(Browser browser, string email, string senha, string emailNavbar)
        {
            TelaHome tela = new TelaHome(_configuration, browser);

            tela.CarregarPagina();
            RealizarLogin(tela, email, senha);

            string resultado = tela.ObterTexto("navbarDropdownEmail");
            tela.Fechar();

            Assert.Equal(emailNavbar, resultado);
        }

        [Theory]
        [InlineData(Browser.Chrome, 8, "Ignition!: An Informal History of Liquid Rocket Propellants")]
        [InlineData(Browser.Chrome, 6, "Blockchain Para Negócios. Promessa, Prática e Aplicação da Nova Tecnologia da Internet")]
        public void TestarAdicionarAoCarrinho(Browser browser, int id, string tituloLivro)
        {
            TelaHome tela = new TelaHome(_configuration, browser);

            tela.CarregarPagina();

            RealizarLogin(tela);
            AdicionarItemAoCarrinho(tela, id);

            string resultado = tela.ObterTexto(id.ToString());
            tela.Fechar();

            Assert.Equal(tituloLivro, resultado);
        }

        [Theory]
        [InlineData(Browser.Chrome, "Compra feita com sucesso, seu pedido está em processamento")]
        public void TestarFinalizarCompra(Browser browser, string textoNotificacao)
        {
            TelaHome tela = new TelaHome(_configuration, browser);

            tela.CarregarPagina();
            RealizarLogin(tela);
            tela.IrParaTelaDoCarrinho();

            if(tela.ObterTexto("resultadoCarrinho") == "Não há nenhum item no carrinho.")
            {
                AdicionarItemAoCarrinho(tela);
            }

            tela.ProcessarCarrinho();
            tela.ProcessarEnderecoDeEntrega();
            tela.ProcessarFormaDePagamento();

            string resultado = tela.ObterTexto("message");
            tela.Fechar();

            Assert.Contains(textoNotificacao, resultado);

        }

        private void RealizarLogin(TelaHome tela, string email = "msn.dosamuel@gmail.com", string senha = "@Placo2019")
        {
            tela.IrParaTelaDeLogin();
            tela.PreencherLogin(email, senha);
            tela.ProcessarLogin();
        }

        private void AdicionarItemAoCarrinho(TelaHome tela, int id = 6)
        {
            tela.IrParaTelaHome();
            tela.IrParaTelaDeDetalhes(id);
            tela.ProcessarAddAoCarrinho();
            tela.IrParaTelaDoCarrinho();
        }
    }
}
