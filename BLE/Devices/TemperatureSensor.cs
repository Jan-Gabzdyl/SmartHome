using System.Security.Authentication.ExtendedProtection;
using System.ComponentModel.Design;
using System.Security.Cryptography;
using HashtagChris.DotNetBlueZ;
using HashtagChris.DotNetBlueZ.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Bluetooth.Devices
{
    public class TemperatureSensor
    {
        public const string ServiceUUID = "4fafc201-1fb5-459e-8fcc-c5c9c331914f";
        public const string TemperatureCharacteristicUUID = "bacdf072-0828-11ec-9a03-0242ac130003";
        public const string HumidityCharacteristicUUID = "e67d52b2-0828-11ec-9a03-0242ac130003";
        public const string PressureCharacteristicUUID = "01d6a036-0829-11ec-9a03-0242ac130003";
        public const string PlaceCharacteristicUUID = "4aa4ab02-08c7-11ec-9a03-0242ac130003";


        public string Place { get; set; }
        public string Temperature { get; set; }
        public string Humidity { get; set; }
        public string Pressure { get; set; }
        public Device Device {get; set; }

        public async Task TemperatureValueChanged(GattCharacteristic characteristic, GattCharacteristicValueEventArgs e)
        {
            try
            {
                byte[] value = await characteristic.ReadValueAsync(new Dictionary<string, Object>());
                Temperature = Encoding.UTF8.GetString(value);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine( ex.Message );
            }
        }

        public async Task HumidityValueChanged(GattCharacteristic characteristic, GattCharacteristicValueEventArgs e)
        {
            try
            {
                byte[] value = await characteristic.ReadValueAsync(new Dictionary<string, Object>());
                Humidity = Encoding.UTF8.GetString(value);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine( ex.Message );
            }
        }

        public async Task PressureValueChanged(GattCharacteristic characteristic, GattCharacteristicValueEventArgs e)
        {
            try
            {
                byte[] value = await characteristic.ReadValueAsync(new Dictionary<string, Object>());
                Pressure = Encoding.UTF8.GetString(value);
            }
            catch (System.Exception)
            {
            }
        }

        public async Task ReadValues ()
        {
                var service = await Device.GetServiceAsync(ServiceUUID);
                if (service == null)
                {
                    Console.WriteLine($"Service UUID {ServiceUUID} not found. Do you need to pair first?");
                    return;
                }
                var c = await service.GetCharacteristicsAsync();
                foreach (var i in  c)
                {
                    System.Console.WriteLine(await i.GetUUIDAsync());
                }

                var tempearatureCharacteristic = await service.GetCharacteristicAsync(TemperatureCharacteristicUUID);
                if (tempearatureCharacteristic == null)
                {
                    Console.WriteLine($"Characteristic UUID {TemperatureCharacteristicUUID} not found within service {ServiceUUID}.");
                    return;
                }

                var humidityCharacteristic = await service.GetCharacteristicAsync(HumidityCharacteristicUUID);
                if (humidityCharacteristic == null)
                {
                    Console.WriteLine($"Characteristic UUID {HumidityCharacteristicUUID} not found within service {ServiceUUID}.");
                    return;
                }

                var pressureCharacteristic = await service.GetCharacteristicAsync(PressureCharacteristicUUID);
                if (pressureCharacteristic == null)
                {
                    Console.WriteLine($"Characteristic UUID {PressureCharacteristicUUID} not found within service {ServiceUUID}.");
                    return;
                }
        
                tempearatureCharacteristic.Value += TemperatureValueChanged;
                humidityCharacteristic.Value += HumidityValueChanged;
                pressureCharacteristic.Value += PressureValueChanged;


                byte[] value = await tempearatureCharacteristic.ReadValueAsync(new Dictionary<string, Object>());
                Temperature = Encoding.UTF8.GetString(value);

                byte[] value2 = await humidityCharacteristic.ReadValueAsync(new Dictionary<string, Object>());
                Humidity = Encoding.UTF8.GetString(value2);

                byte[] value3 = await pressureCharacteristic.ReadValueAsync(new Dictionary<string, Object>());
                Pressure = Encoding.UTF8.GetString(value3);
        }

        public async Task WriteNewPlace (string newPlace)
        {
             var service = await Device.GetServiceAsync(ServiceUUID);

            if (service == null)
            {
                Console.WriteLine($"Service UUID {ServiceUUID} not found. Do you need to pair first?");
                return;
            }
             

            var placeCharacteristic= await service.GetCharacteristicAsync(PlaceCharacteristicUUID);

            if (placeCharacteristic == null)
            {
                Console.WriteLine($"Characteristic UUID {PlaceCharacteristicUUID} not found within service {ServiceUUID}.");
                return;
            }

            await placeCharacteristic.WriteValueAsync(Encoding.UTF8.GetBytes(newPlace), new Dictionary<string, Object>());
            Place = newPlace;
        }

        public async Task<string> ReadPlace ()
        {
            var service = await Device.GetServiceAsync(ServiceUUID);

            if (service == null)
            {
                Console.WriteLine($"Service UUID {ServiceUUID} not found. Do you need to pair first?");
                return "";
            }
             

            var placeCharacteristic = await service.GetCharacteristicAsync(PlaceCharacteristicUUID);

            if (placeCharacteristic == null)
            {
                Console.WriteLine($"Characteristic UUID {PlaceCharacteristicUUID} not found within service {ServiceUUID}.");
                return "";
            }

            byte[] value = await placeCharacteristic.ReadValueAsync(new Dictionary<string, Object>());
            var place = Encoding.UTF8.GetString(value);
            return place;
        }
    }
}