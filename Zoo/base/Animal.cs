using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    class Animal : IAnimal
    {
        public string Name { get; set; }
        public int Energy { get; set; }
        public string Voice { get; set; }
        public bool CanEat { get; set; }

        public Animal(string name, int energy, bool canEat)
        {
            Name = name;
            Energy = energy;
            CanEat = canEat;
        }

        public void MakeSound(IAnimal animal)
        {
            Console.WriteLine(animal.Voice);
        }
    }
}
