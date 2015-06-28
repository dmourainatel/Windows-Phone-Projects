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

namespace ListBox
{
    public partial class MainPage : PhoneApplicationPage
    {

        List<Appointment> ListApp = new List<Appointment>();
        List<Appointment> ListOther = new List<Appointment>();

        public MainPage()
        {
            InitializeComponent();
        }

        protected void EventoMostrar()
        {
            Appointments appts = new Appointments();

            appts.SearchCompleted += new EventHandler<AppointmentsSearchEventArgs>(Appointments_SearchCompleted);

            DateTime start = DateTime.Now;
            DateTime end = start.AddDays(7);
            int max = 20;

            appts.SearchAsync(start, end, max);
        }
        //preenche a lista com todos os eventos, email ou phone ( ambos são hotmail)
        protected void Appointments_SearchCompleted(object sender, AppointmentsSearchEventArgs e)
        {
            foreach (Appointment appt in e.Results)
            {
                ListApp.Add(appt);
            }

            AppointmentShow();
        }
        private void ApplicationBarAddButton_Click(object sender, EventArgs e)
        {
            EventoMostrar();
        }
        //filtra a lista ListApp
        public void AppointmentShow()
       {
           
            for (int i = 0; i < ListApp.Count; i++)
            {
                if (ListApp.ElementAt(i).Subject != null)
                {
                    ListOther.Add(ListApp.ElementAt(i));                          
                }
            }

            lbxItens.ItemsSource = ListOther;
        }

        private void lbxItens_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Appointment selectedAppointment = lbxItens.SelectedItem as Appointment;
            MessageBox.Show(selectedAppointment.Subject + "\n" + selectedAppointment.StartTime.ToString() + "\n");
        }
    }
}