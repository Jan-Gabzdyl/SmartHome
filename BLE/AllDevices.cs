using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashtagChris.DotNetBlueZ;
using HashtagChris.DotNetBlueZ.Extensions;
using SmartHome.Bluetooth.Devices;

namespace SmartHome.Bluetooth
{
    public class AllDevices
    {
        
        public List<LightSwitch> LightSwitches { get; set; } = new();
        public List<TemperatureSensor> TemperatureSensors { get; set; } = new();

        public AllDevices()
        {
        
        }

        public async void ConnectToDevice(Device device)
        {
            device.Connected += device_ConnectedAsync;
            device.Disconnected += device_DisconnectedAsync;
            device.ServicesResolved += device_ServicesResolvedAsync;
            Console.WriteLine($"Connecting to {await device.GetAddressAsync()}...");
            try
            {
                await device.ConnectAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private async Task device_ConnectedAsync(Device device, BlueZEventArgs e)
        {
            try
            {
                if (e.IsStateChange)
                {
                    Console.WriteLine($"Connected to {await device.GetAddressAsync()}");
                }
                else
                {
                    Console.WriteLine($"Already connected to {await device.GetAddressAsync()}");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }

        private async Task device_DisconnectedAsync(Device device, BlueZEventArgs e)
        {
            Console.WriteLine($"Disconnected from {await device.GetAddressAsync()}");

            var tempSensor = TemperatureSensors.FirstOrDefault(t => t.Device == device);
            TemperatureSensors.Remove(tempSensor);

            var lightSwitch = LightSwitches.FirstOrDefault(l => l.Device == device);
            LightSwitches.Remove(lightSwitch);
            
            await Bluetooth.Adapter.RemoveDeviceAsync(device.ObjectPath);
        }

        private async Task device_ServicesResolvedAsync(Device device, BlueZEventArgs e)
        {
            try
            {
                if (e.IsStateChange)
                {
                    Console.WriteLine($"Services resolved for {await device.GetAddressAsync()}");
                }
                else
                {
                    Console.WriteLine($"Services already resolved for {await device.GetAddressAsync()}");
                }
                bool isAnyService = false;
                var servicesUUIDs = await device.GetUUIDsAsync();
                Console.WriteLine($"Device offers {servicesUUIDs.Length} service(s).");
                foreach (var uuid in servicesUUIDs)
                {
                    if (uuid.Equals(BlueZManager.NormalizeUUID(TemperatureSensor.ServiceUUID)))
                    {
                        Console.WriteLine("Found good service");
                        isAnyService = true;
                        TemperatureSensor tempSensor = new();
                        tempSensor.Device = device;
                        var place = await tempSensor.ReadPlace();
                        if (string.IsNullOrEmpty(place))
                        {
                            tempSensor.Place = "Nie przypisano";
                        }
                        else
                        {
                            tempSensor.Place = await tempSensor.ReadPlace();;
                        }
                        await tempSensor.ReadValues();
 
                        TemperatureSensors.Add(tempSensor);          
                    }

                    else if (uuid.Equals(BlueZManager.NormalizeUUID(LightSwitch.ServiceUUID)))
                    {
                        Console.WriteLine("Found good service");
                        isAnyService = true;
                        LightSwitch lightSwitch = new();
                        lightSwitch.Device = device;
                        var place = await lightSwitch.ReadPlace();
                        if (string.IsNullOrEmpty(place))
                        {
                            lightSwitch.Place = "Nie przypisano";
                        }
                        else
                        {
                             lightSwitch.Place = place;
                        }

                        LightSwitches.Add(lightSwitch);          
                    }
                }

                if (isAnyService == false)
                {
                    await device.DisconnectAsync();
                }
            }

            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }
    }
}