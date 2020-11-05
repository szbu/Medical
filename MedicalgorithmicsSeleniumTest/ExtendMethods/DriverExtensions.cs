using MedicalgorithmicsSeleniumTest.Utils;
using MedicalgorithmicsSeleniumTest.WaitMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MedicalgorithmicsSeleniumTest.ExtendMethods
{
    public static class DriverExtensions
    {
        public static IWebElement FindElementExtension(this IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(AppConfig.Timeout));
            wait.Until(ExpectedConditions.PageIsLoaded());
            wait.Until(ExpectedConditions.InvisibilityOfElement(By.CssSelector(".qode-page-loading-effect-holder:not([style='display: none;'])")));
            return wait.Until(ExpectedConditions.VisibilityOfElement(by));
        }

        public static ReadOnlyCollection<IWebElement> FindElementsExtension(this IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(AppConfig.Timeout));
            wait.Until(ExpectedConditions.PageIsLoaded());
            wait.Until(ExpectedConditions.InvisibilityOfElement(By.CssSelector(".qode-page-loading-effect-holder:not([style='display: none;'])")));
            return wait.Until(ExpectedConditions.VisibilityOfElements(by));
        }
    }
}
