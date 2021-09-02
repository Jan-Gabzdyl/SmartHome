using HashtagChris.DotNetBlueZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashtagChris.DotNetBlueZ;
using HashtagChris.DotNetBlueZ.Extensions;

namespace SmartHome.Bluetooth.Devices
{
    public class LightSwitch
    {
        public const string ServiceUUID = "b1a2837c-082e-11ec-9a03-0242ac130005";
        public const string SwitchCharacteristicUUID = "faaa6e3c-082d-11ec-9a03-0242ac130003";
        public const string PlaceCharacteristicUUID= "4aa4ab02-08c7-11ec-9a03-0242ac130003";

        public string Place { get; set; }
        public bool IsOn { get; set; } = false;
        public Device Device { get; set; }


        public async Task ChangeState()
        {
            var service = await Device.GetServiceAsync(ServiceUUID);

            if (service == null)
            {
                Console.WriteLine($"Service UUID {ServiceUUID} not found. Do you need to pair first?");
                return;
            }
             

            var lightSwitchCharacteristic = await service.GetCharacteristicAsync(SwitchCharacteristicUUID);

            if (lightSwitchCharacteristic == null)
            {
                Console.WriteLine($"Characteristic UUID {SwitchCharacteristicUUID} not found within service {ServiceUUID}.");
                return;
            }

            if (IsOn)
            {
                 await lightSwitchCharacteristic.WriteValueAsync(Encoding.ASCII.GetBytes("false"), new Dictionary<string, Object>());
            }
            else
            {
                 await lightSwitchCharacteristic.WriteValueAsync(Encoding.ASCII.GetBytes("true"), new Dictionary<string, Object>());
            }
            IsOn = !IsOn;
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
             

            var placeCharacteristic= await service.GetCharacteristicAsync(PlaceCharacteristicUUID);

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