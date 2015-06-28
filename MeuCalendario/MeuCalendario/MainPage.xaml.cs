using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MeuCalendario.Resources;
using WPControls;
using System.Windows.Media;
using System.Diagnostics;

namespace MeuCalendario
{
    public partial class MainPage : PhoneApplicationPage
    {
        
        
        // Constructor
        public MainPage()
        {
            InitializeComponent();
           
            // Sample code to localize the ApplicationBar
           //BuildLocalizedApplicationBar();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            Cal.StartingDayOfWeek = DayOfWeek.Monday;
            Cal.EnableGestures = true;
        }

        private void Cal_MonthChanged(object sender, WPControls.MonthChangedEventArgs e)
        {
            Debug.WriteLine("Cal_MonthChanged fired.  New year is " + e.Year.ToString() + " new month is " + e.Month.ToString());
        }

        private void Cal_MonthChanging(object sender, WPControls.MonthChangedEventArgs e)
        {
            Debug.WriteLine("Cal_MonthChanging fired.  New year is " + e.Year.ToString() + " new month is " + e.Month.ToString());
        }

        private void Cal_SelectionChanged(object sender, WPControls.SelectionChangedEventArgs e)
        {
            Debug.WriteLine("Cal_SelectionChanged fired.  New date is " + e.SelectedDate.ToString());
        }

        private void Cal_DateClicked(object sender, WPControls.SelectionChangedEventArgs e)
        {
            Debug.WriteLine("Cal_DateClicked fired." + e.SelectedDate.ToString());
        }      
    }

    public class ColorConverter : WPControls.IDateToBrushConverter
    {

        public Brush Convert(DateTime dateTime, bool isSelected, Brush defaultValue, BrushType brushType)
        {
            if (brushType == BrushType.Background)
            {
                if (dateTime == new DateTime(DateTime.Today.Year, DateTime.Today.Month, 2) || dateTime == new DateTime(DateTime.Today.Year, DateTime.Today.Month, 11) || dateTime == new DateTime(DateTime.Today.Year, DateTime.Today.Month, 21) || dateTime == new DateTime(DateTime.Today.Year, DateTime.Today.Month, 30))
                {
                    return new SolidColorBrush(Colors.Yellow);
                }
                else
                {
                    return defaultValue;
                }
            }
            else
            {
                if (dateTime == new DateTime(DateTime.Today.Year, DateTime.Today.Month, 6))
                {
                    return new SolidColorBrush(Colors.Cyan);
                }
                else
                {
                    return defaultValue;
                }
            }

        }
    }

}