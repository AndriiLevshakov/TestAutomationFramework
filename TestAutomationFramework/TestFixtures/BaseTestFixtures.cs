using Core;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace TestLayer
{
    public class BaseTestFixtures
    {
        protected IConfigurationRoot Configuration { get; }

        public BaseTestFixtures() 
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        protected string BaseUrl => Configuration.GetSection("AppSettings")["BaseUrl"];

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
