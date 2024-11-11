using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cat murzik = new Cat("Мурзик", 4.5);
            Cat barsik = new Cat("Барсик", 5.0);
            Cat cat = new Cat("кот", -3); 

            murzik.Meow();
            barsik.Meow();
            cat.Meow();

            barsik.Name = "Барсик123";
            barsik.Meow();

            barsik.Weight = -2; 
            barsik.Meow();

            barsik.Weight = 6.2; 
            barsik.Meow();
            Console.ReadLine();
        }
    }
}
