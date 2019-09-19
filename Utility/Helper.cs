using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specflowselenium.Utility
{
   static class Helper
    {

        public static Boolean WaitForElementClickable(IWebDriver driver, IWebElement element)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(d => (bool)(element as IWebElement).Enabled && (element as IWebElement).Displayed);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static void WaitTillPageLoadComplete(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(d => (IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete");
           

        }
        public static bool IsElementPresent(By by, IWebDriver Driver)
        {
            try
            {
                Driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
