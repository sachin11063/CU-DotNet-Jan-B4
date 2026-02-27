using System;
using System.Collections.Generic;

namespace SmartKitchen
{
    public abstract class KitchenAppliance
    {
        public string ModelName { get; set; }
        public int PowerConsumptionWatts { get; set; }

        protected KitchenAppliance(string modelName, int power)
        {
            ModelName = modelName;
            PowerConsumptionWatts = power;
        }

        public abstract void Cook();

        public virtual void Preheat()
        {
            Console.WriteLine($"{ModelName}: No preheating required.");
        }
    }

    public interface ITimer
    {
        void SetTimer(int minutes);
    }

    public interface IWiFiEnabled
    {
        void ConnectToWiFi(string networkName);
    }

    public class Microwave : KitchenAppliance, ITimer
    {
        public Microwave(string modelName, int power)
            : base(modelName, power)
        {
        }

        public void SetTimer(int minutes)
        {
            Console.WriteLine($"{ModelName}: Timer set for {minutes} minutes.");
        }

        public override void Cook()
        {
            Console.WriteLine($"{ModelName}: Cooking food using microwave radiation.");
        }
    }

    public class ElectricOven : KitchenAppliance, ITimer, IWiFiEnabled
    {
        public ElectricOven(string modelName, int power)
            : base(modelName, power)
        {
        }

        public void SetTimer(int minutes)
        {
            Console.WriteLine($"{ModelName}: Timer set for {minutes} minutes.");
        }

        public void ConnectToWiFi(string networkName)
        {
            Console.WriteLine($"{ModelName}: Connected to WiFi network '{networkName}'.");
        }

        public override void Preheat()
        {
            Console.WriteLine($"{ModelName}: Preheating oven to required temperature...");
        }

        public override void Cook()
        {
            Console.WriteLine($"{ModelName}: Baking food evenly using electric heating elements.");
        }
    }

    public class AirFryer : KitchenAppliance
    {
        public AirFryer(string modelName, int power)
            : base(modelName, power)
        {
        }

        public override void Cook()
        {
            Console.WriteLine($"{ModelName}: Cooking quickly using rapid air circulation.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<KitchenAppliance> appliances = new List<KitchenAppliance>
            {
                new Microwave("QuickHeat 2000", 1200),
                new ElectricOven("AeroCook Pro", 2400),
                new AirFryer("CrispMaster 300", 1500)
            };

            foreach (var appliance in appliances)
            {
                Console.WriteLine("\n-------------------------");
                Console.WriteLine($"Model: {appliance.ModelName}");
                Console.WriteLine($"Power: {appliance.PowerConsumptionWatts}W");

                appliance.Preheat();
                appliance.Cook();

                if (appliance is ITimer timerDevice)
                {
                    timerDevice.SetTimer(10);
                }

                if (appliance is IWiFiEnabled wifiDevice)
                {
                    wifiDevice.ConnectToWiFi("HomeNetwork");
                }
            }

            Console.ReadLine();
        }
    }
}