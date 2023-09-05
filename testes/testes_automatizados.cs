using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

class TestesAutomatizados
{
    void Insercao(IWebDriver driver)
    {
        
        System.Threading.Thread.Sleep(3000);

        driver.FindElement(By.Id("meuBotaocliente")).Click();

        System.Threading.Thread.Sleep(3000);

        driver.FindElement(By.Id("nomeCliente")).SendKeys("Paulo Silva de Oliveira");
        System.Threading.Thread.Sleep(1000);
        IWebElement generoSelect = driver.FindElement(By.Id("genero"));

        generoSelect.Click();

        IWebElement optionMasculino = driver.FindElement(By.CssSelector("#genero option[value='1']"));
        optionMasculino.Click();

        System.Threading.Thread.Sleep(1000);
        driver.FindElement(By.Id("telefone")).SendKeys("11956475179");

        System.Threading.Thread.Sleep(1000);
        IWebElement tipoTelefoneSelect = driver.FindElement(By.Id("tipoTelefone"));

        tipoTelefoneSelect.Click(); 

        IWebElement optionCelular = driver.FindElement(By.CssSelector("#tipoTelefone option[value='2']"));
        optionCelular.Click();
        
        System.Threading.Thread.Sleep(1000);

        driver.FindElement(By.Id("dataNascimento")).SendKeys("01/01/1990");

        System.Threading.Thread.Sleep(1000);

        driver.FindElement(By.Id("emailCliente")).SendKeys("cliente123@gmail.com");

        System.Threading.Thread.Sleep(1000);
        
        driver.FindElement(By.Id("cpfCliente")).SendKeys("12345678900");

        System.Threading.Thread.Sleep(1000);

        IWebElement statusClienteCheckbox = driver.FindElement(By.Id("statusCliente"));

        statusClienteCheckbox.Click();
        
        System.Threading.Thread.Sleep(1000);

        IWebElement popupCliente = driver.FindElement(By.CssSelector(".popup-cliente"));

        IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
        jsExecutor.ExecuteScript("arguments[0].scrollTop += 400;", popupCliente);

        System.Threading.Thread.Sleep(1000);

        driver.FindElement(By.Id("numeroCartao")).SendKeys("1234.5678.9012.3456");
        System.Threading.Thread.Sleep(1000);
        driver.FindElement(By.Id("validade")).SendKeys("12/25");
        System.Threading.Thread.Sleep(1000);
        driver.FindElement(By.Id("cvv")).SendKeys("123");
        System.Threading.Thread.Sleep(1000);
        driver.FindElement(By.Id("titular")).SendKeys("Paulo S de Oliveira");
        System.Threading.Thread.Sleep(1000);
        driver.FindElement(By.Id("cpf")).SendKeys("12345678900");
        
        System.Threading.Thread.Sleep(1000);

        jsExecutor.ExecuteScript("arguments[0].scrollTop += 600;", popupCliente);

        System.Threading.Thread.Sleep(1000);

        driver.FindElement(By.Id("cidadeCliente")).SendKeys("Cidade da Amostra");
        System.Threading.Thread.Sleep(1000);

        driver.FindElement(By.Id("bairroCliente")).SendKeys("Bairro da Amostra");
        System.Threading.Thread.Sleep(1000);

        driver.FindElement(By.Id("numeroEndereco")).SendKeys("123");
        System.Threading.Thread.Sleep(1000);

        driver.FindElement(By.Id("cep")).SendKeys("12345-678");
        System.Threading.Thread.Sleep(1000);

        IWebElement tipoResidenciaSelect = driver.FindElement(By.Id("tipoResidencia"));

        tipoResidenciaSelect.Click(); 

        IWebElement optionResidencia = driver.FindElement(By.CssSelector("#tipoResidencia option[value='2']"));

        optionResidencia.Click();

        System.Threading.Thread.Sleep(1000);

        IWebElement tipoLogradouroSelect = driver.FindElement(By.Id("tipoLogradouro"));

        tipoLogradouroSelect.Click(); 

        IWebElement optionLogradouro = driver.FindElement(By.CssSelector("#tipoLogradouro option[value='2']"));

        optionLogradouro.Click();

        System.Threading.Thread.Sleep(1000);

        driver.FindElement(By.Id("estadoCliente")).SendKeys("Estado da Amostra");

        System.Threading.Thread.Sleep(1000);

        driver.FindElement(By.Id("paisCliente")).SendKeys("País da Amostra");

        System.Threading.Thread.Sleep(1000);

        driver.FindElement(By.Id("confirmar-cliente")).Click();
    }

    void Alteracao(IWebDriver driver)
    { 
        System.Threading.Thread.Sleep(3000);


        driver.FindElement(By.Id("editar-cliente")).Click();

        System.Threading.Thread.Sleep(3000);

        driver.FindElement(By.Id("emailCliente")).SendKeys("outroemail@gmail.com");
        driver.FindElement(By.Id("telefone")).SendKeys("11958324313");
        
        System.Threading.Thread.Sleep(2000);

        driver.FindElement(By.Id("confirmar-cliente")).Click();

        driver.FindElement(By.Id("fechar")).Click();
    }

    void Exclusao(IWebDriver driver)
    {
        System.Threading.Thread.Sleep(3000);

        driver.FindElement(By.Id("excluir-cliente")).Click();
    }

    void Consulta(IWebDriver driver)
    {
        IWebElement termoPesquisaInput = driver.FindElement(By.Id("termoPesquisa"));

        termoPesquisaInput.SendKeys("Paulo");

        driver.FindElement(By.Id("consultarClientes")).Click();


        System.Threading.Thread.Sleep(3000);

        termoPesquisaInput.Clear();

        termoPesquisaInput.SendKeys("1990");

        driver.FindElement(By.Id("consultarClientes")).Click();

        System.Threading.Thread.Sleep(3000);

        termoPesquisaInput.Clear();

        termoPesquisaInput.SendKeys("Ativo");

        driver.FindElement(By.Id("consultarClientes")).Click();

        System.Threading.Thread.Sleep(5000);

        driver.FindElement(By.Id("inativar-cliente")).Click();

        System.Threading.Thread.Sleep(3000);


    }

    static void Main(string[] args)
    {
        string chromedriverPath = @"C:\Users\lucas\OneDrive\Área de Trabalho\ecommerce full\testes\chromedriver-win64\chromedriver.exe"; 

        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument("--start-maximized"); 

        IWebDriver driver = new ChromeDriver(chromedriverPath, chromeOptions);

        string paginaHTMLPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "EcommerceBack","Views", "Cliente", "Cliente.html");

        driver.Url = "http://localhost:7247/Cliente/Cliente";
        
        var testes = new TestesAutomatizados(); 

        testes.Insercao(driver); 
        //testes.Alteracao(driver);
        //testes.Exclusao(driver);
        testes.Consulta(driver);

    }
}