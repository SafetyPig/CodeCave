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
    /// Interaction logic for loadAnimation.xaml
    /// </summary>
    public partial class loadAnimation : UserControl
    {
        public loadAnimation()
        {
            InitializeComponent();
        }

        /*
        public static readonly RoutedEvent loadEvent = EventManager.RegisterRoutedEvent(
            "Animation", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(loadAnimation));

        public event RoutedEventHandler Animation
        {
            add { AddHandler(loadEvent, value); }
            remove { RemoveHandler(loadEvent, value); }
        }

        public void raiseAnimation()
        {
            RoutedEventArgs eventArgs = new RoutedEventArgs(loadAnimation.loadEvent);
            RaiseEvent(eventArgs);
        }

        */
    }
}
