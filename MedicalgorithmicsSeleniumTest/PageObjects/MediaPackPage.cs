using MedicalgorithmicsSeleniumTest.ExtendMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalgorithmicsSeleniumTest.PageObjects
{
    public class MediaPackPage
    {
        private IWebDriver driver;

        public MediaPackPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement LogoDownloadLink => driver.FindElementExtension(By.CssSelector("div.wpb_wrapper a[href='https://www.medicalgorithmics.pl/wp-content/uploads/2018/10/logotypy.zip']:not([target=_self])"));

        public void ClickAtLogoDownloadLink()
        {
            LogoDownloadLink.ClickAndDownloadFile(driver, ".zip");
        }
    }
}
