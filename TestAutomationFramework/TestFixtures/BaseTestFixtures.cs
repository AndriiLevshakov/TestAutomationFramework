using Core;
using System.Configuration;

namespace TestLayer
{
    public class BaseTestFixtures
    {
        public string BaseUrl { get; } = ConfigurationManager.AppSettings["BaseUrl"];

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
