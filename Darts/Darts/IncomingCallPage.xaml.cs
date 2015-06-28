using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Threading;
using Microsoft.Devices;

namespace Darts
{
    public partial class IncomingCallPage : PhoneApplicationPage
    {
        DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };

        DispatcherTimer vibrationTimer = new DispatcherTimer();

        bool isRinging;
        int vibrationStep;

        public IncomingCallPage()
        {
            InitializeComponent();
            this.timer.Tick += timer_Tick;
            this.vibrationTimer.Tick += vibrationTimer_Tick;
        }

        protected override void OnMouseLeftButtonDown(System.Windows.Input.MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if(this.WaitingForCallPanel.Visibility == System.Windows.Visibility.Visible)
            {
                this.CountdownTextBlock.Visibility = System.Windows.Visibility.Collapsed;
                this.TapToHideTextBlock.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.CarrierTextBlock.Text = Settings.Carrier.Value;
            this.PhoneNumberTextBlock.Text = Settings.PhoneNumber.Value;

            this.timer.Start();

            timer_Tick(null,null);
            StopRinging();

            PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;                      
        }

        void StartRinging()
        {
            isRinging = true;
            this.WaitingForCallPanel.Visibility = Visibility.Collapsed;
            this.IncomingCallPanel.Visibility = System.Windows.Visibility.Visible;
            this.vibrationStep = 0;
            this.vibrationTimer.Start();
        }

        private void StopRinging()
        {
            isRinging = false;
            this.WaitingForCallPanel.Visibility = Visibility.Visible;
            this.IncomingCallPanel.Visibility = System.Windows.Visibility.Collapsed;
            this.vibrationTimer.Stop();
            Settings.CallTime.Value = DateTime.Now + TimeSpan.FromMinutes(2);
            timer_Tick(null, null);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            this.timer.Stop();          
        }

        void vibrationTimer_Tick(object sender, EventArgs e)
        {
            switch (this.vibrationStep % 4)
            {
                case 0:
                case 2:
                    VibrateController.Default.Start(TimeSpan.FromSeconds(.1));
                    this.vibrationTimer.Interval = TimeSpan.FromSeconds(.4);
                    break;
                case 1:
                    VibrateController.Default.Start(TimeSpan.FromSeconds(.4));
                    this.vibrationTimer.Interval = TimeSpan.FromSeconds(.8);
                    break;
                case 3:
                    VibrateController.Default.Start(TimeSpan.FromSeconds(.4));
                    this.vibrationTimer.Interval = TimeSpan.FromSeconds(2.1);
                    break;
            }
            this.vibrationStep++;

            if (this.vibrationStep == 24)
                StopRinging();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            this.CurrentTimeTextBlock.Text = DateTime.Now.ToString("h:mm");

            TimeSpan delta = Settings.CallTime.Value - DateTime.Now;

            if(delta>TimeSpan.Zero)
            {
                this.CurrentTimeTextBlock.Text = "COUNTDOWN: " + (int)delta.TotalHours + ":"
                    + delta.Minutes.ToString("00") + ":"
                    + Math.Ceiling((double)delta.Seconds).ToString("00");
            }
            else if(!this.isRinging)
            {
                StartRinging();
            }
        }

        private void AnswerButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/CallProgressPage.xaml", 
                UriKind.Relative));
        }

        private void btnIgnore_Click(object sender, RoutedEventArgs e)
        {
            StopRinging();
        }
    }
}