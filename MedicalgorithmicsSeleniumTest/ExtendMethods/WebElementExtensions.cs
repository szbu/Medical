using MedicalgorithmicsSeleniumTest.Utils;
using MedicalgorithmicsSeleniumTest.WaitMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalgorithmicsSeleniumTest.ExtendMethods
{
    public static class WebElementExtensions
    {
        public static void ClickWithScroll(this IWebElement element, IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(AppConfig.Timeout));
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
            wait.Until(ExpectedConditions.PageIsLoaded());
            javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView({ behavior: 'auto', block: 'center' });", element);
            wait.Until(ExpectedConditions.ElementIsClickable(element));
            element.Click();
        }

        public static void ClickAndDownloadFile(this IWebElement element, IWebDriver driver, string fileType)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(AppConfig.Timeout));
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
            wait.Until(ExpectedConditions.PageIsLoaded());
            javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView({ behavior: 'auto', block: 'center' });", element);
            element.Click();
            wait.Until(ExpectedConditions.IsFileDownloaded(fileType));
        }

        public static void ClickWithScrollToBottom(this IWebElement element, IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(AppConfig.Timeout));
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
            javaScriptExecutor.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            wait.Until(ExpectedConditions.ElementIsClickable(element));
            element.Click();
        }

        public static void MoveToElement(this IWebElement element, IWebDriver driver)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Build().Perform();
        }
    }
}
