using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLayer.TestFixtures
{
    public static class ScreenShot
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public static void CaptureScreenshot(IWebDriver driver, string testName)
        {
            try
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string fileName = $"screenshot_{testName}_{DateTime.Now:yyyyMMddHHmmss}.png";

            }
        }
    }
}
