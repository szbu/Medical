using MedicalgorithmicsSeleniumTest.ExtendMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalgorithmicsSeleniumTest.PageObjects
{
    public class SearchResultPage
    {
        private IWebDriver driver;

        public SearchResultPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        ReadOnlyCollection<IWebElement> PostList => driver.FindElementsExtension(By.CssSelector(".latest_post_custom"));
        ReadOnlyCollection<IWebElement> PostTitleList => driver.FindElementsExtension(By.CssSelector(".text-title"));
        IWebElement PaginationRightArrow => driver.FindElementExtension(By.CssSelector("li.next a[href^='https://www.medicalgorithmics.pl/page/2?s=']"));


        public int GetPostListCount()
        {
            return PostList.Count();
        }

        public List<string> GetPostTitleList()
        {
            List<string> postTitles = new List<string>();
            foreach(IWebElement element in PostTitleList)
            {
                postTitles.Add(element.Text);
            }
            return postTitles;
        }

        public void ClickAtPaginationRightArrow()
        {
            PaginationRightArrow.ClickWithScrollToBottom(driver);
        }
    }
}
