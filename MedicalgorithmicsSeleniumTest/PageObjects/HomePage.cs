using MedicalgorithmicsSeleniumTest.ExtendMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalgorithmicsSeleniumTest.PageObjects
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement MediaPackLink => driver.FindElementExtension(By.CssSelector("div.footer_top a[href='https://www.medicalgorithmics.pl/media-pack/']"));

        public void ClickAtMediaPackLink()
        {
            MediaPackLink.ClickWithScroll(driver);
        }
    }
}
