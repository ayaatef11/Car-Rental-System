//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using System.Diagnostics;
//using System.Net;
//using Car_Rental_System.WebScraping.Interfaces;
//using Microsoft.Extensions.Configuration;

//namespace Car_Rental_System.WebScraping.Services;


//    public class AtraScraper : IAtraScraper
//    {
//        private IWebDriver _driver;
//        private readonly IConfiguration _configuration;
//        private readonly DbContextOptions<AppDbContext> _dbContextOptions;

//        public AtraScraper()
//        {
//            _configuration = new ConfigurationBuilder()
//                         .SetBasePath(Directory.GetCurrentDirectory())  // Get the current directory
//                         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//                         .Build();
//            var connectionString = _configuration.GetConnectionString("RunGroopDb");
//            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
//            optionsBuilder.UseSqlServer(connectionString);
//            _dbContextOptions = optionsBuilder.Options;
//            _driver = new ChromeDriver();
//        }

//        public void Run()
//        {
//            IterateOverRaceElements();
//        }

//        public IReadOnlyCollection<IWebElement> GetElements()
//        {
//            return _driver.FindElements(By.CssSelector("span[itemprop='name']"));
//        }

//        public void IterateOverRaceElements()
//        {
//            _driver.Navigate().GoToUrl("https://trailrunner.com/race-calendar/");
//            Thread.Sleep(3000);
//            var eventRows = _driver.FindElements(By.CssSelector("tr[itemtype='http://schema.org/Event']"));
//            foreach (var row in eventRows)
//            {
//                var cells = row.FindElements(By.TagName("td"));


//                string date = cells[0].Text.Trim();
//                var linkElement = cells[1].FindElement(By.TagName("a"));
//                string name = linkElement.Text.Trim();
//                string link = linkElement.GetAttribute("href");
//                var distancesList = cells[2].FindElements(By.CssSelector("ul li"));
//                string distances = string.Join(", ", distancesList.Select(d => d.Text.Trim()));
//                string type = cells[3].Text.Trim();
//                string location = cells[4].Text.Trim();
//                Console.WriteLine($"Date: {date}\nName: {name}\nLink: {link}\nDistances: {distances}\nType: {type}\nLocation: {location}");
//                Console.WriteLine("--------------------------------------------------");
            
//            }

//            _driver.Quit();
//        }
//    }


