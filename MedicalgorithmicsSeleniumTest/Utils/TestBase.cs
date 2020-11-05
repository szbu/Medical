using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalgorithmicsSeleniumTest.Utils
{
    public class TestBase : IDisposable
    {
        protected IWebDriver driver;

        public void BrowserSetUp(string browserName)
        {
            FilesOperations.DeleteDownloadedFiles();
            driver = BrowserFactory.InitializeDriver(browserName);
            driver.Navigate().GoToUrl(AppConfig.Url);
            driver.Manage().Window.Maximize();
            Cookie en = new Cookie("wp-wpml_current_language", "en");
            Cookie pl = new Cookie("wp-wpml_current_language", "pl");
            Cookie acceptCookies = new Cookie("cookie_notice_accepted", "true");

            driver.Manage().Cookies.AddCookie(pl);
            driver.Manage().Cookies.AddCookie(en);
            driver.Manage().Cookies.AddCookie(acceptCookies);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
