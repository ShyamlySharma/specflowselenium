namespace specflowselenium.Bindings
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using specflowselenium.Utility;
    using System;
    using TechTalk.SpecFlow;

    [Binding]
    class SpecflowBindings
    {
        private IWebDriver Driver;

        [When(@"I start the browser")]
        public void WhenIStartTheBrowser()
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"D:\testworkspace\specflowselenium-master-main\specflowselenium-master\specflowselenium");
            Driver = new FirefoxDriver(service);
            Driver.Manage().Window.Maximize();
        }

        [When(@"I navigate to '(.*)'")]
        public void WhenINavigateToHttpExample_Com(string Url)
        {
            Driver.Navigate().GoToUrl(Url);
        }

        [When(@"I click on the '(.*)'")]
        public void WhenIClickOnThe(string Text)
        {
            //this method will check if the page is loaded completely
            Helper.WaitTillPageLoadComplete(Driver);
            
            //Using tagname the webelement can also be located
            //IWebElement MoreInfomationLink = Driver.FindElement(By.TagName("a"));
            
            IWebElement MoreInfomationLink = Driver.FindElement(By.XPath("//a[text()='"+ Text + "']"));
            MoreInfomationLink.Click();
            Console.WriteLine("User Clicked on More Information link successfully");

        }

        [Then(@"a link with text '(.*)' must be present")]
        public void ThenALinkWithTextMustBePresent(string LinkText)
        {
            Helper.WaitTillPageLoadComplete(Driver);
            Assert.IsTrue(Helper.IsElementPresent(By.XPath("//a[text()='" + LinkText + "']"), Driver));
            Console.WriteLine(LinkText + " is Present");

        }
        [Then(@"a Link with text '(.*)' must be present")]
        public void AndALinkWithTextMustBePresent(string LinkText)
        {
            Assert.IsTrue(Helper.IsElementPresent(By.XPath("//a[text()='" + LinkText + "']"), Driver));
            Console.WriteLine(LinkText + " is Present");
        }

        [Then(@"the '(.*)' box must contain '(.*)' at index '(.*)'")]
        public void ThenTheBoxMustContainAtIndex(string Domainheader, string ZoneText, int index)
        {
            IWebElement DomainName = Driver.FindElement(By.XPath("//div[@class='navigation_box']//h2"));
            Console.WriteLine(DomainName.Text);
            Assert.AreEqual(DomainName.Text, Domainheader);


            IWebElement Index2Element = Driver.FindElement(By.XPath("(//div[@class='navigation_box']//li)["+ index + "]/a"));
            Console.WriteLine(Index2Element.Text);
            Assert.AreEqual(Index2Element.Text, ZoneText);

            Driver.Quit();

        }
    }
}
