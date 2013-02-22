using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherTeller
{
    class Day
    {
        public string date { get; set; }
        public string degrees { get; set; }
        public string description { get; set; }
        

        public Day()
        {
        }

        /// <summary>
        /// Konstruktori, jolla voi antaa päivän ja lämpötilan
        /// </summary>
        /// <param name="date">päivämäärä stringinä</param>
        /// <param name="degrees">lämpötila stringinä</param>
        public Day(string date, string degrees, string description)
        {
            if (date.Equals("Tänään"))
            {
                this.date = DateTime.Today.Date.ToShortDateString();
            }

            else if (date.Equals("Huomenna"))
            {
                this.date = DateTime.Today.Date.AddDays(1).ToShortDateString();
            }

            else
            {
                date = date.Substring(3, date.Length - 3);
                this.date = date + DateTime.Today.Year; //ei toimi uutena vuotena.
            }

            this.degrees = degrees;
            this.description = description;
        }
    }
}
