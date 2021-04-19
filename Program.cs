using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Protractor;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestareSoft
{
    class Program
    {
        private static IWebDriver driver;

        
        static void Main(string[] args)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-notifications");
            driver = new ChromeDriver(options);

            
            siteSearch("https://www.google.com/", new Xpaths().googleXpath, new Xpaths().googleHeader);
            //siteSearch("https://www.youtube.com/", new Xpaths().youtubeXpath, new Xpaths().youtubeHeader);
            //siteSearch("https://www.amazon.com/", new Xpaths().amazonXpath, new Xpaths().amazonHeader);
            //siteSearch("https://www.ebay.com/", new Xpaths().ebayXpath, new Xpaths().ebayHeader);
            //siteSearch("https://www.aliexpress.com/", new Xpaths().aliexpressXpath, new Xpaths().aliexpressHeader);
            //siteSearch("https://999.md/ru/", new Xpaths().md999Xpath, new Xpaths().md999Header);
            //siteSearch("https://www.reddit.com/", new Xpaths().redditXpath, new Xpaths().redditHeader);
            //siteSearch("https://9gag.com/", new Xpaths().gang9Xpath, new Xpaths().gang9Header);

        }
        
        //google test
        static void siteSearch(string siteUrl, string searchXpath, string headerXpath)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(siteUrl);
            if (siteUrl == "https://9gag.com/")
            {
                driver.FindElement(By.XPath("//a[@class='search']")).Click();
            }
            var search = driver.FindElement(By.XPath(searchXpath));
            search.Click();
            search.SendKeys("computer");
            search.SendKeys(Keys.Enter);

            if (driver.FindElement(By.XPath(headerXpath)) != null)
            {
                Console.WriteLine("Header is displayed");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Header is not displayed");
                Console.ReadLine();
            }
        }
    }
}