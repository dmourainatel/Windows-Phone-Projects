using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Darts.Resources;

namespace Darts
{
    public partial class MainPage : PhoneApplicationPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            
            this.phoneNumberTextBox.Text = Settings.PhoneNumber.Value;
            this.carrierTextBox.Text = Settings.Carrier.Value;

            if (Settings.CallTime.Value > DateTime.Now)
                this.TimePicker.Value = Settings.CallTime.Value;
            else
                this.TimePicker.Value = DateTime.Now;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            Settings.CallTime.Value = this.TimePicker.Value ?? DateTime.Now;
            Settings.PhoneNumber.Value = this.phoneNumberTextBox.Text;
            Settings.Carrier.Value = this.carrierTextBox.Text;
        }

        private void btnWaitForCall_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/IncomingCallPage.xaml",UriKind.RelativeOrAbsolute));
        }

        private void TimePicker_ValueChanged(object sender, DateTimeValueChangedEventArgs e)
        {
            Settings.CallTime.Value = e.NewDateTime ?? DateTime.Now;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).SelectAll();
        }

        private void TextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == System.Windows.Input.Key.Enter)
            {
                if (sender == this.phoneNumberTextBox)
                    this.carrierTextBox.Focus();
                else if (sender == this.carrierTextBox)
                    this.TimePicker.Focus();

                e.Handled = true;
            }
        }
    }
}