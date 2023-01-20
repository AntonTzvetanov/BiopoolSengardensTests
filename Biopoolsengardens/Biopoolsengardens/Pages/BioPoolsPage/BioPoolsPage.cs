using Biopoolsengardens.BioPoolsPage;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Reflection;

namespace Biopoolsengardens.Pages
{

    [TestFixture]
    public class TestsPoolsPage
    {

        private IWebDriver _driver;
        private BioPoolsPageElements _poolsPage;


        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            _poolsPage = new BioPoolsPageElements(_driver);

            _poolsPage.Navigate();

            _poolsPage.Maximize();
        }

        [Test]
     
        public void NavigatetoPoolsPageAndVerifyThatHeaderTextIsDisplayed()
        {
            _poolsPage.CookieButton.Click();
            _poolsPage.BioPoolsPageButton.Click();
            Assert.That(_poolsPage.BiopoolsInfoTextHeader.Displayed);
            Assert.That(_poolsPage.BiopoolsInfoTextHeader.Text.ToString().Contains("Biozwembaden"));

        }

        [Test]
        public void VerifyBiopoolsInfoIsDisplayed()
        {
            _poolsPage.CookieButton.Click();
            _poolsPage.BioPoolsPageButton.Click();
            
            Assert.That(_poolsPage.BiopoolsInfoText.Displayed);

            Assert.That(_poolsPage.BioPoolsPageButton.Displayed);
            
        }



        [TearDown]
        public void TearDown()
        {
            var name = TestContext.CurrentContext.Test.Name;
            var result = TestContext.CurrentContext.Result.Outcome;

            if (result != ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                var directory = Directory.GetCurrentDirectory();

                var fullPath = Path.GetFullPath("..\\..\\..\\Screenshots");

                screenshot.SaveAsFile(fullPath + name + ".png", ScreenshotImageFormat.Png);

            }
            _driver.Quit();


        }
    }
}