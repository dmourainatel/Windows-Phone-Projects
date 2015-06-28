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

namespace Darts
{
    public partial class CallInProgress : PhoneApplicationPage
    {
        DispatcherTimer timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1)
        };

        TimeSpan callDuration;

        public CallInProgress()
        {
            InitializeComponent();
            this.timer.Tick += timer_Tick;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            this.CurrentTextBlock.Text = DateTime.Now.ToString("h:mm");

            this.callDuration = this.callDuration.Add(TimeSpan.FromSeconds(1));
            this.CallDurationTextBlock.Text = (int)this.callDuration.TotalMinutes + ":" + this.callDuration.Seconds.ToString("00");
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            this.CarrierTextBlock.Text = Settings.Carrier.Value;
            this.PhoneNumberTextBlock.Text = Settings.PhoneNumber.Value;

            this.callDuration = TimeSpan.Zero - TimeSpan.FromSeconds(1);

            this.timer.Start();
            timer_Tick(null,null);

            PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            this.timer.Stop();

            Settings.CallTime.Value = DateTime.Now + TimeSpan.FromSeconds(2);

            PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Enabled;
        }

        private void EndCallButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
                this.NavigationService.GoBack();
        }
    }
}