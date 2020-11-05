using MedicalgorithmicsSeleniumTest.ExtendMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalgorithmicsSeleniumTest.PageObjects
{
    public class MegaMenuNavBar
    {
        private IWebDriver driver;
        public MegaMenuNavBar(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement ContactLink => driver.FindElementExtension(By.CssSelector("nav.main_menu #mega-menu-item-29 a"));
        IWebElement ContactLinkHover => driver.FindElementExtension(By.CssSelector("nav.main_menu #mega-menu-item-29 a:hover"));
        IWebElement SearchIcon => driver.FindElementExtension(By.CssSelector("span.icon_search"));
        IWebElement SearchField => driver.FindElementExtension(By.CssSelector("input.qode_search_field"));
        IWebElement ArrowRightIcon => driver.FindElementExtension(By.CssSelector("span.arrow_right"));

        public string GetContactLinkColour()
        {
            return ContactLink.GetCssValue("color");
        }

        public string GetContactLinkColourAfterMouseOver()
        {
            ContactLink.MoveToElement(driver);
            return ContactLinkHover.GetCssValue("color");
        }

        public void ClickAtSearchIcon()
        {
            SearchIcon.ClickWithScroll(driver);
        }

        public void TypeIntoSearchField(string searchValue)
        {
            SearchField.SendKeys(searchValue);
        }

        public void ClickAtArrowRightIcon()
        {
            ArrowRightIcon.ClickWithScroll(driver);
        }
    }
}
