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
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("test-type");
            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("--ignore-certificate-errors");
            driver = new ChromeDriver(@"C:\Users\HP\Downloads\chromedriver_win32\chromedriver.exe", options);


            //var servce = ChromeDriverService.CreateDefaultService();
            //this.driver = new ChromeDriver(servce);
            this.baseUrl = "https://meteo.paraplan.net/";

            this.driver.Navigate().GoToUrl(this.baseUrl);

        }

        [TestMethod]
        public void TestMeteoFiveDays()
        {
            this.driver.FindElement(By.XPath("/html/body/div[3]/div/nav/div[2]/div[1]/a")).Click();
            this.driver.FindElement(By.XPath("//span[text()= 'Five-day weather forecast'] "));
        }


        [TestCleanup]
        public void CleanUp()
        {
            this.driver.Close();
            this.driver.Quit();
        }

    }
}

