using OpenQA.Selenium;

namespace Core
{
    public static class WebDriverManager
    {
        private static IWebDriver? _driver;

        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    _driver = WebDriverFactory.CreateChromeDriver();
                }

                return _driver;
            }
        }

        public static void QuitDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();

                _driver = null;
            }
        }
    }
}
