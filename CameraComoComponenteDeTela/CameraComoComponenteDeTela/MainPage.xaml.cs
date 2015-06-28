using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CameraComoComponenteDeTela.Resources;
using Microsoft.Devices;
using System.Windows.Media.Imaging;

namespace CameraComoComponenteDeTela
{
    public partial class MainPage : PhoneApplicationPage
    {

        private PhotoCamera _cam;
        //private bool _firstPhoto = true;

        public MainPage()
        {
            InitializeComponent();

        }

        //Code for initialization, capture completed, image availability events; also setting the source for the viewfinder.
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            //_firstPhoto = true;
            viewfinderCanvas.Visibility = Visibility.Visible;
            imgLeft.Visibility = Visibility.Collapsed;
            //imgRight.Visibility = Visibility.Collapsed;
            // Check to see if the camera is available on the device.
            if ((PhotoCamera.IsCameraTypeSupported(CameraType.Primary) == true))
            {
                // Otherwise, use standard camera on back of device.
                _cam = new Microsoft.Devices.PhotoCamera(CameraType.Primary);

                // Event is fired when the PhotoCamera object has been initialized.
                _cam.Initialized += new EventHandler<Microsoft.Devices.CameraOperationCompletedEventArgs>(cam_Initialized);

                // Event is fired when the capture sequence is complete.
                // _cam.CaptureCompleted += new EventHandler<CameraOperationCompletedEventArgs>(cam_CaptureCompleted);

                // Event is fired when the capture sequence is complete and a thumbnail image is available.
                _cam.CaptureThumbnailAvailable += new EventHandler<ContentReadyEventArgs>(cam_CaptureThumbnailAvailable);

                // Event is fired when the capture sequence is complete and an image is available.
                //_cam.CaptureImageAvailable += new EventHandler<Microsoft.Devices.ContentReadyEventArgs>(cam_CaptureImageAvailable);

                // The event is fired when the shutter button receives a half press.
                CameraButtons.ShutterKeyHalfPressed += OnButtonHalfPress;

                // The event is fired when the shutter button receives a full press.
                CameraButtons.ShutterKeyPressed += OnButtonFullPress;

                // The event is fired when the shutter button is released.
                CameraButtons.ShutterKeyReleased += OnButtonRelease;

                //Set the VideoBrush source to the camera.
                viewfinderBrush.SetSource(_cam);
            }
            else
            {
                // The camera is not supported on the device.
                this.Dispatcher.BeginInvoke(delegate()
                {
                    // Write message.
                    txtDebug.Text = "A Camera is not available on this device.";
                });
            }
        }
        protected override void OnNavigatingFrom(System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            if (_cam != null)
            {
                // Dispose camera to minimize power consumption and to expedite shutdown.
                _cam.Dispose();
                // Release memory, ensure garbage collection.
                _cam.Initialized -= cam_Initialized;
                //_cam.CaptureCompleted -= cam_CaptureCompleted;
                //_cam.CaptureImageAvailable -= cam_CaptureImageAvailable;
                _cam.CaptureThumbnailAvailable -= cam_CaptureThumbnailAvailable;
                _cam.AutoFocusCompleted -= cam_AutoFocusCompleted;
                //CameraButtons.ShutterKeyHalfPressed -= OnButtonHalfPress;
                CameraButtons.ShutterKeyPressed -= OnButtonFullPress;
                // CameraButtons.ShutterKeyReleased -= OnButtonRelease;
            }
        }

        // Update the UI if initialization succeeds.
        void cam_Initialized(object sender, Microsoft.Devices.CameraOperationCompletedEventArgs e)
        {
            if (e.Succeeded)
            {
                this.Dispatcher.BeginInvoke(delegate()
                {
                    // Write message.
                    txtDebug.Text = "Camera initialized.";
                });
            }
        }
        void cam_AutoFocusCompleted(object sender, CameraOperationCompletedEventArgs e)
        {
            Deployment.Current.Dispatcher.BeginInvoke(delegate()
            {
                // Write message to UI.
                txtDebug.Text = "Auto focus has completed.";

                // Hide the focus brackets.
                focusBrackets.Visibility = Visibility.Collapsed;

            });
        }
        void cam_CaptureCompletedx(object sender, CameraOperationCompletedEventArgs e)
        {

        }

        void cam_CaptureThumbnailAvailable(object sender, ContentReadyEventArgs e)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                BitmapImage image = new BitmapImage();
                image.SetSource(e.ImageStream);
                    imgLeft.Source = image;
                    imgLeft.Visibility = Visibility.Visible;
                e.ImageStream.Close();
            });
        }

        void cam_CaptureImageAvailable(object sender, Microsoft.Devices.ContentReadyEventArgs e)
        {

            try
            {   
                Deployment.Current.Dispatcher.BeginInvoke(delegate()
                {
                    txtDebug.Text = "Captured image available, saving picture.";
                });
            }
            finally
            { }

        }
        private void OnButtonHalfPress(object sender, EventArgs e)
        {
            if (_cam != null)
            {
                try
                {
                    _cam.Focus();
                }
                catch (Exception focusError)
                {
                    this.Dispatcher.BeginInvoke(delegate()
                    {
                        txtDebug.Text = focusError.Message;
                    });
                }
            }
        }
        private void OnButtonRelease(object sender, EventArgs e)
        {
            if (_cam != null)
            {
                txtDebug.Text = "";
                try
                {
                    _cam.CancelFocus();
                }
                catch
                { }
            }
        }
        private void OnButtonFullPress(object sender, EventArgs e)
        {
            if (_cam != null)
            {
                txtDebug.Text = "FullPress";
                _cam.FlashMode = FlashMode.Off;
                _cam.CaptureImage();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _cam.CaptureImage();
        }

    }
}