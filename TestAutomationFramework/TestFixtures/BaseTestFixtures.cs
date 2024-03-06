using Core;

namespace TestLayer
{
    public class BaseTestFixtures
    {
        public string BaseUrl { get; } = "https://www.epam.com/";

        [SetUp]
        public void SetUp()
        {
            WebDriverManager.Driver.Navigate().GoToUrl(BaseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            WebDriverManager.QuitDriver();
        }
    }
}
