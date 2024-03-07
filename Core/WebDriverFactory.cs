
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Core
{
    public static  class WebDriverFactory
    {
        public static IWebDriver CreateChromeDriver()
        {
            string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string downloadPath = Path.Combine(userPath, "Downloads");

            var options = new ChromeOptions();
            options.AddArguments("--headless");
            options.AddArguments("--window-size=1920,1080");
            options.AddUserProfilePreference("download.default_directory", downloadPath);


            return new ChromeDriver(options);

        }
    }
}
