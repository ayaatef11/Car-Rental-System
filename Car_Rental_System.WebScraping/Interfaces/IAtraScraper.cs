using OpenQA.Selenium;

namespace Car_Rental_System.WebScraping.Interfaces;
    internal interface IAtraScraper
    {
        IReadOnlyCollection<IWebElement> GetElements();
        void IterateOverRaceElements();
        void Run();
    }

