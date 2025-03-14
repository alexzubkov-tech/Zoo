using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.classes;

namespace Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IAnimal> list_animals = new List<IAnimal>();
            Zoo zoo = new Zoo("Цирк уродов", "МГТУ", list_animals);

            while (true)
            {
                Console.WriteLine("\nГлавное меню:");
                Console.WriteLine("1. Добавить льва");
                Console.WriteLine("2. Покормить животное");
                Console.WriteLine("3. Посмотреть список животных");
                Console.WriteLine("4. Выход");

                int choice = GetValidIntInput("Выберите действие: ", 1, 4);

                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("\nДобавление льва:");

                            Console.Write("Имя: ");
                            string name_lion = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(name_lion))
                            {
                                Console.Write("Имя не может быть пустым. Введите снова: ");
                                name_lion = Console.ReadLine();
                            }

                            int energy_lion = GetValidIntInput("Энергия (0-100): ", 0, 100);
                            bool caneat_lion = energy_lion < 100;

                            Lion lion = new Lion(name_lion, energy_lion, caneat_lion);
                            list_animals.Add(lion);

                            Console.WriteLine("Лев успешно добавлен!\n");
                            break;
                        }

                    case 2:
                        {
                            if (list_animals.Count == 0)
                            {
                                Console.WriteLine("В зоопарке нет животных для кормления.\n");
                                break;
                            }

                            List<IAnimal> CanEatAnimals = new List<IAnimal>();
                            for (int i = 0; i < list_animals.Count; i++)
                            { 
                                if (list_animals[i].CanEat == true)
                                    CanEatAnimals.Add(list_animals[i]);
                            }

                            if (CanEatAnimals.Count == 0)
                            {
                                Console.WriteLine("В зоопарке все животные накормлены");
                                break;
                            }
                            else
                            { 
                                Console.WriteLine("\nСписок животных для кормления:");
                                for (int i = 0; i < CanEatAnimals.Count; i++)
                                {
                                    Console.WriteLine($"1 - {CanEatAnimals[i].Name}");
                                }
                            
                                int choice_Feed = GetValidIntInput("Выберите номер животного для кормления: ", 1, CanEatAnimals.Count);
                                zoo.FeedAnimal(zoo, CanEatAnimals[choice_Feed - 1]);

                                Console.WriteLine("Животное накормлено!\n");
                                break;
                            }
                        }
                    case 3:
                        {
                            if (list_animals.Count == 0)
                            {
                                Console.WriteLine("В зоопарке пока нет животных.\n");
                            }
                            else
                            {
                                Console.WriteLine("\nСписок животных:");
                                zoo.ViewListAnimals(zoo);
                            }
                            break;
                        }

                    case 4:
                        {
                            Console.WriteLine("Выход из программы...");
                            return;
                        }
                }
            }
        }

        static int GetValidIntInput(string message, int min, int max)
        {
            int result;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out result) && result >= min && result <= max)
                {
                    return result;
                }
                Console.WriteLine($"Ошибка: Введите число от {min} до {max}.");
            }
        }
    }
}
