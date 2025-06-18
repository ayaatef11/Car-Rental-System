using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_System.WebScraping.Interfaces
{
    internal interface IAtraScraper
    {
        IReadOnlyCollection<IWebElement> GetElements();
        void IterateOverRaceElements();
        void Run();
    }
}
