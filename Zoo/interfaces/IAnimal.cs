using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    interface IAnimal
    {
        string Name { get; set; }
        int Energy { get; set; }
        string Voice { get; set; }
        bool CanEat { get; set; }

        void MakeSound(IAnimal animal);
    }
}
