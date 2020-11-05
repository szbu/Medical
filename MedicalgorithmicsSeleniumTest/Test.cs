using MedicalgorithmicsSeleniumTest.PageObjects;
using MedicalgorithmicsSeleniumTest.Utils;
using MedicalgorithmicsSeleniumTest.WaitMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MedicalgorithmicsSeleniumTest
{
    public class Test : TestBase
    {
        [Theory]
        [InlineData("Chrome")]
        [InlineData("MozillaFirefox")]
        public void Test1(string browserName)
        {
            BrowserSetUp(browserName);

            MegaMenuNavBar megaMenuNavBar = new MegaMenuNavBar(driver);
            Assert.NotEqual(megaMenuNavBar.GetContactLinkColour(), megaMenuNavBar.GetContactLinkColourAfterMouseOver());

            HomePage homePage = new HomePage(driver);
            homePage.ClickAtMediaPackLink();

            MediaPackPage mediaPackPage = new MediaPackPage(driver);
            mediaPackPage.ClickAtLogoDownloadLink();

            Assert.Equal("logotypy.zip", FilesOperations.GetDownloadedFileName());

            FilesOperations.ExtractFile("logotypy.zip");
            Assert.True(FilesOperations.CheckFileExistInDownloadFolder("MA_logo_standard_claim_MONO.pdf"));
        }

        [Theory]
        [InlineData("Chrome")]
        [InlineData("MozillaFirefox")]
        public void Test2(string browserName)
        {
            BrowserSetUp(browserName);

            MegaMenuNavBar megaMenuNavBar = new MegaMenuNavBar(driver);
            megaMenuNavBar.ClickAtSearchIcon();
            megaMenuNavBar.TypeIntoSearchField("Pocket ECG CRS");
            megaMenuNavBar.ClickAtArrowRightIcon();

            SearchResultPage searchResultPage = new SearchResultPage(driver);
            Assert.Equal(10, searchResultPage.GetPostListCount());
            Assert.Single(searchResultPage.GetPostTitleList(), "PocketECG CRS – telerehabilitacja kardiologiczna");

            searchResultPage.ClickAtPaginationRightArrow();
            Assert.Equal(4, searchResultPage.GetPostListCount());

        }
    }
}
