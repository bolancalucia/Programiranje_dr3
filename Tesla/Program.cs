using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesla
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine Engine1 = new Engine()
            {
                Model = "Model1",
                DistanceTraveled = 9000,
                EnergyPerKM = 1,
                LastChecked = new DateTime(2013, 4, 23),
                Power = 250
            };

            Engine Engine2 = new Engine()
            {
                Model = "Model2",
                DistanceTraveled = 11000,
                EnergyPerKM = 4,
                LastChecked = new DateTime(2011, 4, 23),
                Power = 1200
            };

            Battery Battery1 = new Battery("B1", Engine1.Power, 1000, 50); // Jel triba snaga?
            Battery Battery2 = new Battery("B2", Engine2.Power, 5000, 250);

            Car Car1 = new Car("Skoda Octavia", Engine1, Battery1);
            Car Car2 = new Car("Nissan GTR", Engine2, Battery2);

            Console.WriteLine(Car2.Battery.StoredEnergy);
            Car2.Drive(100);
            Console.WriteLine(Car2.Battery.StoredEnergy);


        }

        public enum CarModels {Regular, Super, Extra, Xenon }

        class Battery
        {
            public string Model;
            public double StoredEnergy;
            public double MaximumStoredEnergy;

            public Battery(string model,double power,double maximumEnergy, double PricePerWh) // SNAGA NE TRIBA U KONSTRUKTORU ??
            {
                Model = model;
                StoredEnergy = power;
                MaximumStoredEnergy = maximumEnergy;
            }

            public void SpendEnergy(double amount)
            {
                StoredEnergy -= amount;
                if (StoredEnergy < 0)
                    StoredEnergy = 0;
            }

            public void Recharge(double amount)
            {
                StoredEnergy += amount;
                if (StoredEnergy > MaximumStoredEnergy)
                    StoredEnergy = MaximumStoredEnergy;
            }
        }

        class Engine
        {
            public string Model;
            public double DistanceTraveled;
            public double EnergyPerKM;
            public DateTime LastChecked; // = new DateTime();
            public double Power;

            public double Run(double distance)
            {
                DistanceTraveled += distance;
                return distance * EnergyPerKM;
            }

            public bool NeedsRepair()
            {
                if (DistanceTraveled < 10000 && (DateTime.Now - LastChecked).Days < 5*365)
                    return false;
                else return true;
            }

        }

        class Car
        {
            public string Name;
            public CarModels Model;
            public Engine Engine;
            public Battery Battery;

            public Car(string name, Engine engine, Battery battery)
            {
                Name = name;
                Engine = engine;  
                Battery = battery; 

                if (engine.Power < 150)
                    Model = CarModels.Regular;
                else if (engine.Power > 150 && engine.Power < 200)
                    Model = CarModels.Super;
                else if (engine.Power > 200 && engine.Power < 300)
                    Model = CarModels.Extra;
                else if (engine.Power > 300)
                    Model = CarModels.Xenon;
            }

            public void Drive(double distance)
            {
                Battery.SpendEnergy(Engine.Run(distance));              
            }
        }

    }
}
