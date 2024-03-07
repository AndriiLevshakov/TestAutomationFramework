using Business;
using Core;
using NLog;
using OpenQA.Selenium.DevTools.V120.Page;
using TestLayer.TestFixtures;

namespace TestLayer
{
    public class Tests : BaseTestFixtures
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        [TestCase("C#", "All Locations")]
        public void Test1_Careers(string programmingLanguage, string location)
        {
            try
            {
                logger.Info($"Starting Test1_Careers with programming language: {programmingLanguage}, location: {location}");

            var homePage = new HomePage(WebDriverManager.Driver);

            homePage.ClickAcceptButton();
            logger.Info("Clicked Accept Button");

            homePage.ClickCareersLink();
            logger.Info("Clicked Careers Link");

            var careersPage = new CareersPage(WebDriverManager.Driver);

            careersPage.EnterKeywords(programmingLanguage);
            logger.Info($"Entered keywords: {programmingLanguage}");

            careersPage.OpenLocationDropDownMenu();
            logger.Info("Opened location drop down menu");

            careersPage.SelectAllLocations();
            logger.Info("Selected all locations");

            careersPage.SelectRemoteOption();
            logger.Info("Selected remote option");

            careersPage.ClickFindButton();
            logger.Info("Clicked 'Find' button");

            careersPage.ClickSortingLabelByDate();
            logger.Info("Clicked sorting label by date");

            careersPage.GetLatestResul();
            logger.Info("Got latest result");

            Assert.That(careersPage.IsPresentOnThePage(programmingLanguage),
                $"Programming language '{programmingLanguage}' not found on the page");
            logger.Info("Test successfully completed.");
            }
            catch (Exception ex)
            {
                ScreenShot.CaptureScreenshot(WebDriverManager.Driver, nameof(Test1_Careers));

                logger.Error($"An error occurred in Test1_Careers: {ex.Message}");
                throw;
            }
        }

        [TestCase("BLOCKCHAIN")]
        [TestCase("Cloud")]
        [TestCase("Automation")]
        public void Test2_GlobalSearch(string searchKeyword)
        {
            try
            {
            logger.Info($"Starting Test2_GlobalSearch with search keyword: {searchKeyword}");

            var homePage = new HomePage(WebDriverManager.Driver);

            homePage.ClickMagnifierIcon();
            logger.Info("Clicked magnifier icon");

            homePage.SendSearchInputToGlobalSearch(searchKeyword);
            logger.Info("Entered the search keyword into the global search input field");

            homePage.ClickFindButtonForGlobalSearch();
            logger.Info("Clicked 'Find' button for global search");

            Assert.That(homePage.IsSearchKeywordPresentOnThePage(searchKeyword), $"Search keyword '{searchKeyword}' was not found on the page");
            logger.Info("Test successfully completed.");
            }
            catch (Exception ex)
            {
                logger.Error($"An error occurred in Test2_GlobalSearch: {ex.Message}");
                throw;
            }
        }

        [Test]
        public void Test3_ValidateFileDownload()
        {
            try
            {
            logger.Info("Starting the Test3_ValidatiFileDownload");

            var homePage = new HomePage(WebDriverManager.Driver);

            var aboutPage = new AboutPage(WebDriverManager.Driver);

            homePage.ClickAcceptButton();
            logger.Info("Clicked 'Accept' button");

            homePage.ClickAboutLink();
            logger.Info("Clicked 'About' link");

            aboutPage.ClickDownloadButton();
            logger.Info("Clicked 'Download' button");

            Assert.That(aboutPage.IsDownloaded("EPAM_Corporate_Overview_Q4_EOY.pdf"));
            logger.Info("Test successfully completed.");
            }
            catch (Exception ex)
            {
                logger.Error($"An error occurred in Test3_ValidateFileDownload: {ex.Message}");
                throw;
            }
        }

        [Test]
        public void Test4_ValidateArticleTitleInCarousel()
        {
            try
            {
            logger.Info("Starting the Test4_ValidateArticleTitleInCarousel");

            var homePage = new HomePage(WebDriverManager.Driver);

            var insightsPage = new InsightsPage(WebDriverManager.Driver);

            homePage.ClickAcceptButton();
            logger.Info("Clicked 'Accept' button");

            homePage.ClickInsightsLink(); 
            logger.Info("Clicked 'Insights' link");

            insightsPage.SwipeCarouselTwice();
            logger.Info("Swiped carousel twice");

            insightsPage.ClickReadMoreButton(); 
            logger.Info("Clicked 'Read More' button");

            Assert.That(insightsPage.IsActiveSliderTextPresentInTheArticleText());
            logger.Info("Test successfully completed.");
            }
            catch (Exception ex)
            {
                logger.Error($"An error occurred in Test4_ValidateArticleTitleInCarousel: {ex.Message}");
                throw;
            }
        }
    }
}