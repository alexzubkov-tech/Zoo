using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Zoo
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public List<IAnimal> animals { get; set; } = new List<IAnimal>();

        public Zoo(string name, string location)
        {
            Name = name;
            Location = location;
        }

        public void AddAnimal(IAnimal animal)
        {
            animals.Add(animal);
        }

        public void FeedAnimal(Zoo zoo, IAnimal animal)
        {
            animal.Energy += 20;
            if (animal.Energy >= 100) 
                animal.CanEat = false;
        }

        public void ViewListAnimals(Zoo zoo)
        {
            Console.WriteLine($"В зоопарке {zoo.Name} содержатся {zoo.animals.Count} животных:");
            
            for (int i = 0; i < zoo.animals.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {zoo.animals[i].Name} -> {zoo.animals[i].Energy} % энергии");
            }
        }

        public List<IAnimal> CanEatAnimals()
        {
            return animals.Where(a => a.CanEat).ToList();
        }
    }
}
