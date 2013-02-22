using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeatherTeller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Day> dayList;
        loadAnimation animation;

        public MainWindow()
        {
            InitializeComponent();
            loadCity("Hankasalmi");
        }

        /// <summary>
        /// Lataa annetun kaupungin tiedot
        /// </summary>
        /// <param name="city">Haluttu kaupunki</param>
        public void loadCity(string city)
        {
            stackPanelInfo.Children.Clear();

            HtmlParser parser = new HtmlParser();

            if (city.Length <= 0)
                city = "Hankasalmi";

            dayList = parser.loadTenDays(city);
            if (dayList == null)
            {
                Label mistake = new Label();
                mistake.Content = "Moka, ota yhteys koodariin. (Nettisivu on muuttunut シ";
                stackPanelInfo.Children.Add(mistake);
            }

            else
            {
                dayList.Sort(new DayComperator());

                cityLabel.FontSize = 20;
                cityLabel.Content = city;

                foreach (Day paiva in dayList)
                {
                    Label info = new Label();
                    info.Content = "Päivän " + paiva.date + " ennustettu lämpötila on: " + paiva.degrees + " " + paiva.description;
                    stackPanelInfo.Children.Add(info);
                }
            }

            gridBottom.Children.Remove(animation);

        }

        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            animation = new loadAnimation();
            Grid.SetColumn(animation, 1);
            Grid.SetRow(animation, 1);
            string city = "";

            if (ComboBoxCities.SelectedItem != null)
            {
                 city = ((ComboBoxItem)ComboBoxCities.SelectedItem).Content.ToString();
            }

            city.Replace('ä', 'a');
            city.Replace('ö', 'o');
            loadCity(city);           
        }
    }
}
