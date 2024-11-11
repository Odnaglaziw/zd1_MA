using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat
{
    public class Cat
    {
        private string name; 
        private double weight; 

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                bool OnlyLetters = true;
                foreach (var ch in value)
                {
                    if (!char.IsLetter(ch))
                    {
                        OnlyLetters = false;
                    }
                }

                if (OnlyLetters)
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine($"{value} - неправильное имя!!!");
                }
            }
        }
        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value > 0)
                {
                    weight = value;
                }
                else
                {
                    Console.WriteLine("Вес кота не может быть нулевым или отрицательным!");
                }
            }
        }
        public Cat(string CatName, double CatWeight)
        {
            Name = CatName;
            Weight = CatWeight;
        }
        public void Meow()
        {
            Console.WriteLine($"{name}: МЯЯЯЯУ!!!! Вес: {weight} кг");
        }
    }
}
