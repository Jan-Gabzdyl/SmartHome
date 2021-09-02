using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using HashtagChris.DotNetBlueZ;
using HashtagChris.DotNetBlueZ.Extensions;
using Microsoft.Extensions.Hosting;

namespace SmartHome.Bluetooth
{
    public class Bluetooth : IHostedService
    {
        private AllDevices _allDevices;
        public static Adapter Adapter { get; private set; }

        public Bluetooth(AllDevices allDevices)
        {
            _allDevices = allDevices;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Adapter = (await BlueZManager.GetAdaptersAsync()).FirstOrDefault();

            Adapter.PoweredOn += adapter_PoweredOnAsync;
            Adapter.DeviceFound += adapter_DeviceFoundAsync;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            
        }

        private async Task adapter_PoweredOnAsync(Adapter adapter, BlueZEventArgs e)
        {
            try
            {
                if (e.IsStateChange)
                {
                    Console.WriteLine("Bluetooth adapter powered on.");
                }
                else
                {
                    Console.WriteLine("Bluetooth adapter already powered on.");
                }

                Console.WriteLine("Starting scan...");
                await adapter.StartDiscoveryAsync();
                }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }

        private async Task adapter_DeviceFoundAsync(Adapter adapter, DeviceFoundEventArgs e)
        {
            try
            {
                var device = e.Device;

                var deviceDescription = await GetDeviceDescriptionAsync(device);
                if (e.IsStateChange)
                {
                    Console.WriteLine($"Found: [NEW] {deviceDescription}");
                }
                else
                {
                    Console.WriteLine($"Found: {deviceDescription}");
                }
               _allDevices.ConnectToDevice(device);

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }

        private async Task<string> GetDeviceDescriptionAsync(IDevice1 device)
        {
            var deviceProperties = await device.GetAllAsync();
            return $"{deviceProperties.Address} (Alias: {deviceProperties.Alias}, RSSI: {deviceProperties.RSSI})";
        }
    }
}