using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Advertisement;
using System.Diagnostics;
// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace App15
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        BluetoothLEAdvertisementWatcher watcher = new BluetoothLEAdvertisementWatcher();
        public MainPage()
        {
            this.InitializeComponent();
            // Add an event handler for receiving advertisements.
            watcher.Received += OnAdvertisementReceived;
            watcher.Start();
            
        }


        private void OnAdvertisementReceived(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementReceivedEventArgs args)
        {
            // Display the device name and signal strength.
            Trace.WriteLine("Device name: " + args.Advertisement.LocalName);
            Trace.WriteLine("Signal strength: " + args.RawSignalStrengthInDBm);

            // Display the service UUIDs.
            Trace.WriteLine("Service UUIDs:");
            foreach (var uuid in args.Advertisement.ServiceUuids)
            {
                Trace.WriteLine(uuid);
            }

            // Display the manufacturer data.
            Trace.WriteLine("Manufacturer data:");
            /*foreach (var data in args.Advertisement.ManufacturerData)
            {
                Trace.WriteLine("Company ID: " + data.CompanyId);
                Trace.WriteLine("Data: " + BitConverter.ToString(data.Data.ToArray()));
            }
            */
        }

        private void txt1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
