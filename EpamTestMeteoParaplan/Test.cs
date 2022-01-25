using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace EpamTestMeteoParaplan
{
    [TestClass]
    public class Test
    {

        private IWebDriver driver;
        private string baseUrl;


        [TestInitialize]
        public void SetUpTest()
        {
            var servce = ChromeDriverService.CreateDefaultService();
            this.driver = new ChromeDriver(servce);
            this.baseUrl = "https://meteo.paraplan.net/";

            this.driver.Navigate().GoToUrl(this.baseUrl);

        }

        [TestMethod]
        public void TestMeteoFiveDays()
        {
            this.driver.FindElement(By.XPath("/html/body/div[3]/div/nav/div[2]/div[1]/a")).Click();
            this.driver.FindElement(By.XPath("//span[text()= 'Five-day weather forecast'] "));

            this.driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/div[2]/a"));
        }


        [TestCleanup]
        public void CleanUp()
        {
            this.driver.Close();
            this.driver.Quit();
        }

    }
}

