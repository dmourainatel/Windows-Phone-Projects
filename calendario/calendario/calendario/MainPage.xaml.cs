using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.UserData;

namespace calendario
{
    public partial class MainPage : PhoneApplicationPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Appointments appts = new Appointments();
            
            

            appts.SearchCompleted += new EventHandler<AppointmentsSearchEventArgs>(Appointments_SearchCompleted);

            DateTime start = DateTime.Now;
            DateTime end = start.AddDays(7);
            int max = 20;

            appts.SearchAsync(start, end, max);
        }

        void Appointments_SearchCompleted(object sender, AppointmentsSearchEventArgs e)
        {         
            List<Appointment> ListApp = new List<Appointment>();

            foreach (Appointment appt in e.Results)
            {          
                ListApp.Add(appt);
            }

            for (int i = 0; i < ListApp.Count; i++)
            {
                string subject = ListApp[i].Subject.ToString();
                string time = ListApp[i].StartTime.ToString();
                string text = subject + "\n" + time + "\n";           
                MessageBox.Show(text);
            }

        }


    }
}