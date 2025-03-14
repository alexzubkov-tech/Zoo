using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.classes
{
    class Lion: Animal
    {
        string Voice_Lion = "Рррррррр!";
        public Lion(string name, int energy, bool caneat)
            : base(name, energy, caneat) { }
       
    }
}
