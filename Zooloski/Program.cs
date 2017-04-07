using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zooloski
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal Lav = new Animal("Simba", Animals.Lion, 80, new DateTime(2017, 4, 1, 18, 30, 15));
            Animal Slon = new Animal("Dumbo", Animals.Elephant, 2000, new DateTime(2017, 4, 5, 12, 15, 45));

            Console.WriteLine(Lav.Print());
            Lav.IsHungry();
            Lav.Feed();
            Console.WriteLine(Lav.Print() + "\n");

            Zoo ZooVrt = new Zoo()
            {
                Name = "ZOOLOSKI VRT",
                Food = 1000,
                Animals = new List<Animal>() { Lav, Slon }
            };

            foreach (Animal animal in ZooVrt.Animals)
                Console.WriteLine(animal.Print());

            ZooVrt.FeedAnimals();
            Console.WriteLine("");

            foreach (Animal animal in ZooVrt.Animals)
                Console.WriteLine(animal.Print());

        }

        public enum Animals {Giraffe, Lion, Crocodile, Rhino, Elephant}

        class Animal
        {
            public string Name;
            public Animals Animal_;
            public int Weight;
            public DateTime LastFed; // = new DateTime();

            public Animal(string name,Animals animal,int weight,DateTime lastfed)
            {
                Name = name;
                Animal_ = animal; 
                Weight = weight;
                LastFed = lastfed;
            }

            public int Feed()
            {
                LastFed = DateTime.Now;
                int FoodEaten = Weight / 20;
                if (FoodEaten < 1)
                    FoodEaten = 1;

                return FoodEaten;
            }

            public bool IsHungry()
            {
                if ((DateTime.Now - LastFed).Days > Weight / 10 && (DateTime.Now - LastFed).Hours > 24)
                    return true;
                else return false;
            }

            public string Print()
            {
                return $"{Name} {Animal_} {Weight} ({LastFed})";
            }
        }

        class Zoo
        {
            public string Name;
            public double Food;
            public List<Animal> Animals;  // = new List<Animal>(); 

            public void FeedAnimals()
            {
                foreach (Animal animal in Animals)
                {
                    Food -= animal.Feed();
                }
            }
        }
    }
}
