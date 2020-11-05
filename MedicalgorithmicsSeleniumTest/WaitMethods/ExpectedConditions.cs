using MedicalgorithmicsSeleniumTest.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MedicalgorithmicsSeleniumTest.WaitMethods
{
    public class ExpectedConditions
    {
        public static Func<IWebDriver, bool> PageIsLoaded()
        {
            return (driver) =>
            {
                string jQueryUndefined = "return window.jQuery != undefined";
                bool isjQueryNotUndefined = false;
                try
                {
                    isjQueryNotUndefined = Convert.ToBoolean(((IJavaScriptExecutor)driver).ExecuteScript(jQueryUndefined));
                }
                catch (OpenQA.Selenium.WebDriverException)
                {
                    return false;
                }
                bool isAjaxFinished = false;
                try
                {
                    isAjaxFinished = Convert.ToBoolean(((IJavaScriptExecutor)driver).ExecuteScript("return jQuery.active==0"));
                }
                catch (OpenQA.Selenium.WebDriverException)
                {
                    return false;
                }
                if (isAjaxFinished)
                {
                    string isDocumentReady = ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").ToString();
                    if (isDocumentReady == "complete")
                    {
                        int numberOfImages = Convert.ToInt32(((IJavaScriptExecutor)driver).ExecuteScript("return document.images.length"));
                        for (int i = 0; i < numberOfImages; i++)
                        {
                            bool isImageReady = Convert.ToBoolean(((IJavaScriptExecutor)driver).ExecuteScript("return document.images[" + i + "].complete;"));
                        }
                        return true;
                    }
                    return false;
                }
                return false;
            };
        }

        public static Func<IWebDriver, IWebElement> VisibilityOfElement(By by)
        {
            return (driver) =>
            {
                try
                {
                    if (driver.FindElement(by).Displayed)
                    {
                        if (driver.FindElement(by).Size.Width != 0 && driver.FindElement(by).Size.Height != 0)
                        {
                            return driver.FindElement(by);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }

                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        public static Func<IWebDriver, ReadOnlyCollection<IWebElement>> VisibilityOfElements(By by)
        {
            List<IWebElement> elements = new List<IWebElement>();
            return (driver) =>
            {
                try
                {
                    foreach (IWebElement element in driver.FindElements(by))
                    {
                        if (element.Displayed)
                        {
                            if (element.Size.Width != 0 && element.Size.Height != 0)
                            {
                                elements.Add(element);
                            }
                            else
                            {
                                return null;
                            }
                        }
                        else
                        {
                            return null;
                        }
                    }
                    if (elements.Count > 0)
                    {
                        return elements.AsReadOnly();
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        public static Func<IWebDriver, bool> InvisibilityOfElement(By by)
        {
            return (driver) =>
            {
                try
                {
                    if (!driver.FindElement(by).Displayed)
                    {
                        if (driver.FindElement(by).Size.Width.Equals(0) && driver.FindElement(by).Size.Height.Equals(0))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            };
        }

        public static Func<IWebDriver, bool> ElementIsClickable(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    if (element.Displayed && element.Enabled)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            };
        }

        public static Func<IWebDriver, bool> IsFileDownloaded(string fileType)
        {
            return (driver) =>
            {
                DirectoryInfo downloadedDirectory = new DirectoryInfo(AppConfig.DownloadPath);
                FileInfo getFile = downloadedDirectory.GetFiles().Where(x=>x.Extension.Equals(fileType)).FirstOrDefault();
                if(getFile != null)
                {
                    return true;
                }
                return false;
            };
        }
    }
}
