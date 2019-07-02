using System;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.Utils;

namespace ECommerceDeLivros.Testes
{
    public class TelaHome
    {
        private IConfiguration _configuration;
        private Browser _browser;
        private IWebDriver _driver;

        public TelaHome(IConfiguration configuration, Browser browser)
        {
            _configuration = configuration;
            _browser = browser;

            string caminhoDriver = null;
            if (browser == Browser.Chrome)
            {
                caminhoDriver = _configuration.GetSection("Selenium:CaminhoDriverChrome").Value;
            }

            _driver = WebDriveFactory.CreateWebDriver(browser, caminhoDriver);
        }

        public void CarregarPagina()
        {
            _driver.LoadPage(TimeSpan.FromSeconds(20), _configuration.GetSection("Selenium:UrlTelaHome").Value);
        }

        public void PreencherBusca(string textoProcurado)
        {
            _driver.SetText(By.Name("searchString"), textoProcurado);
        }

        public void PreencherLogin(string email, string senha)
        {
            _driver.SetText(By.Id("Email"), email);
            _driver.SetText(By.Id("Senha"), senha);
        }

        public void ProcessarBusca()
        {
            _driver.Submit(By.Name("btnSearch"));

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(By.Id("resultadoBusca")) != null);
        }

        public void ProcessarLogin()
        {
            _driver.Submit(By.Id("btnLogin"));

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(By.Id("navbarDropdownEmail")) != null);
        }

        public void ProcessarAddAoCarrinho()
        {
            _driver.FindElement(By.Id("btnAddAoCarrinho")).Click();
        }

        public void ProcessarCarrinho()
        {
            _driver.FindElement(By.Id("btnContinuarParaEnderecoDeEntrega")).Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(By.Id("btnContinuarParaFormaDePagamento")) != null);
        }

        public void ProcessarEnderecoDeEntrega()
        {
            _driver.FindElement(By.Id("btnContinuarParaFormaDePagamento")).Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(By.Id("btnFinalizarCompra")) != null);
        }

        public void ProcessarFormaDePagamento()
        {
            _driver.FindElement(By.Id("btnFinalizarCompra")).Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(By.Id("message")) != null);
        }

        public void IrParaTelaDeDetalhes(int id)
        {
            _driver.FindElement(By.Name(id.ToString()))
                .FindElement(By.Id("btnLivro")).Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(By.Id("btnAddAoCarrinho")) != null);
        }

        public void IrParaTelaDeLogin()
        {
            _driver.FindElement(By.Id("btnEntrar")).Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(By.Id("Email")) != null);
        }

        public void IrParaTelaDoCarrinho()
        {
            _driver.FindElement(By.Id("navbarDropdownEmail")).Click();
            _driver.FindElement(By.Id("btnVerCarrinho")).Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(By.Id("resultadoCarrinho")) != null);
        }

        public void IrParaTelaHome()
        {
            _driver.FindElement(By.Id("btnHome")).Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public string ObterTexto(string id)
        {
            return _driver.GetText(By.Id(id));
        }

        public string ObterTextoParcialPeloId(string texto)
        {
            return _driver.GetText(By.CssSelector("[id$=" + texto + "]"));
        }

        public void Fechar()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
