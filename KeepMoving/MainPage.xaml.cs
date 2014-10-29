﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

using KeepMoving.Background;
using KeepMoving.Framework;

namespace KeepMoving
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
            Loaded += OnLoaded;
        }

        private async void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            var enable = await Sensor.CheckSensorCoreSupport();
            if (enable)
            {
                BackgroundReadTask.Register();
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void NotifcationsEnabledCheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            //if (!NotifcationsEnabledCheckBox.IsChecked.HasValue)
            //{
            //    //This is only to make intellisense happy
            //    return;
            //}

            //App.NotificationsEnabled = NotifcationsEnabledCheckBox.IsChecked.Value;
        }

        private void NotifcationsEnabledSwitch_OnToggled(object sender, RoutedEventArgs e)
        {
            //NotifcationsEnabledSwitch.
        }
    }
}
