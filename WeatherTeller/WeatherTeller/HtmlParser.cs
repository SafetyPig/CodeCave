using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace WeatherTeller
{
    /// <summary>
    /// Luokka, joka parsii säätiedot nettisivulta
    /// </summary>
    class HtmlParser
    {
        private HtmlDocument doc;
        private List<Day> dayList = new List<Day>();

        /// <summary>
        /// Konstruktori, jolle tuodaan tietona mistä kaupungista parsitaan
        /// </summary>
        public HtmlParser()
        {
        }

        /// <summary>
        /// Lataa kymmenen päivän tiedot
        /// </summary>
        /// <param name="html"> ladattava sivu</param>
        public List<Day> loadTenDays(string city)
        {
            try
            {

                string Url = "http://www.foreca.fi/Finland/" + city + "/tenday";
                HtmlWeb web = new HtmlWeb();
                doc = web.Load(Url);


                //TODO fiksumpi ratkaisu tähän näin
                foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[@class = 'c1 ']"))
                {
                    parseDay(node.InnerHtml.Trim());
                }

                foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[@class = 'c1 clr1']"))
                {
                    parseDay(node.InnerHtml.Trim());
                }

                foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[@class = 'c1 clr5']"))
                {
                    parseDay(node.InnerHtml.Trim());
                }
            }

            catch(Exception)
            {
                return null;
            }

            return dayList;
        }

        public void parseDay(string dayInfo)
        {

            int beg = dayInfo.IndexOf("<strong>");
            int end = dayInfo.IndexOf("</strong>");
            int length = end - beg;
            string degrees = dayInfo.Substring(beg, length);
            degrees = degrees.Substring(8, degrees.Length - 8);
            degrees = degrees.Replace("&deg;", "°C");

            beg = dayInfo.IndexOf("class=\"h5\">");
            end = dayInfo.IndexOf("</span>");
            length = end - beg;
            string date = dayInfo.Substring(beg, length);
            date = date.Substring(11, date.Length - 11);

            beg = dayInfo.IndexOf("alt=");
            end = dayInfo.IndexOf("width");
            length = end - beg;
            string description = dayInfo.Substring(beg,length);
            description = description.Substring(4, length - 4);
            description = description.Replace("\"","");

            dayList.Add(new Day(date, degrees, description));
        }
    }
}
