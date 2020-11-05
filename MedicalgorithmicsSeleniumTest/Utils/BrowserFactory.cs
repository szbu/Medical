using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalgorithmicsSeleniumTest.Utils
{
    public class BrowserFactory
    {
        public static IWebDriver InitializeDriver(string browserName)
        {
            switch (browserName)
            {
                case "MozillaFirefox":
                    {
                        FirefoxDriverService firefoxDriverService = FirefoxDriverService.CreateDefaultService();
                        FirefoxOptions firefoxOptions = new FirefoxOptions();
                        firefoxOptions.SetPreference("browser.download.dir", AppConfig.DownloadPath);
                        firefoxOptions.SetPreference("browser.download.folderList", 2);
                        firefoxOptions.SetPreference("browser.download.manager.showWhenStarting", false);
                        firefoxOptions.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/zip");
                        firefoxOptions.SetPreference("marionette", true);
                        firefoxOptions.PageLoadStrategy = PageLoadStrategy.Normal;
                        return new FirefoxDriver(firefoxDriverService, firefoxOptions, TimeSpan.FromSeconds(180));
                    }
                case "Chrome":
                    {
                        ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.AddUserProfilePreference("download.default_directory", AppConfig.DownloadPath);
                        chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
                        chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
                        return new ChromeDriver(chromeDriverService, chromeOptions, TimeSpan.FromSeconds(180));
                    }
            }
            return null;
        }
    }
}
