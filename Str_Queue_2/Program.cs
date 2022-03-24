using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Str_Queue_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.WriteLine("Введите длину массива:");
            int userMasN;
            while (!int.TryParse(Console.ReadLine(), out userMasN))
            {
                Console.WriteLine("Неверный Ввод числа N! Попробуйте снова:");
            }
            Console.WriteLine("С номера какого элемента начать ввод?");
            int firstIndexOfQ;
            while (!(int.TryParse(Console.ReadLine(), out firstIndexOfQ)) || !(firstIndexOfQ <= userMasN))
            {
                Console.WriteLine("Неверный Ввод индекса первого элемента! Попробуйте снова:");
            }
            Console.WriteLine("Сколько элементов ввести?");
            int amountOfQueueElements;
            while (!(int.TryParse(Console.ReadLine(), out amountOfQueueElements)) || !(amountOfQueueElements <= userMasN - firstIndexOfQ))
            {
                Console.WriteLine("Неверный Ввод количества элементов очереди! Попробуйте снова:");
            }
            string[] massive = new string[userMasN];
            for (int i = firstIndexOfQ; i < amountOfQueueElements + firstIndexOfQ; i++)
            {
                Console.Write($"Введите элемент номер {i}:");
                massive[i] = Console.ReadLine();
            }
            for (int i = firstIndexOfQ; i < amountOfQueueElements + firstIndexOfQ; i++)
            {
                Console.WriteLine($"Элемент №{i} равен {massive[i]}");
            }

            while (true)
            {
                bool isProgrammEnd = false;
                Console.WriteLine("1.Очистить стек\n2.Проверить, пуст ли стек\n3.Распечатать стек\n4.Добавить в конец стека элемент\n5.Удалить последний элемент из стека\n6-9 Завершить работу?");
                int userInput = -1;
                while (!int.TryParse(Console.ReadLine(), out userInput))
                {
                    Console.WriteLine("Неверный Ввод числа! Попробуйте снова:");
                }
                switch (userInput)
                {
                    case 1:
                        ClearStack(massive);
                        break;
                    case 2:
                        if (CheckIfStackIsEmpty(massive))
                        {
                            Console.WriteLine("Стек пуст!");
                            break;
                        }
                        Console.WriteLine("Стек не пуст!");
                        break;
                    case 3:
                        PrintStack(massive);
                        break;
                    case 4:
                        Console.WriteLine("Какой элемент добавить в очередь?");
                        AddToStack(massive, Console.ReadLine());
                        break;
                    case 5:
                        string str;
                        RemoveFromStack(massive, out str);
                        if (str != null)
                        {
                            Console.WriteLine($"Был удален элемент:{str}");
                            break;
                        }
                        Console.WriteLine("ИСЧЕРПАНИЕ СТЕКА!");
                        break;
                    default:
                        isProgrammEnd = true;
                        break;
                }
                if (isProgrammEnd)
                {
                    Console.WriteLine("Программа завершила своё выполнение.");
                    break;
                }
            }

            void ClearStack(string[] mass)
            {
                for (int i = 0; i < mass.Length; i++)
                {
                    mass[i] = null;
                }
            }

            bool CheckIfStackIsEmpty(string[] mass)
            {
                for (int i = 0; i < mass.Length; i++)
                {
                    if (mass[i] != null)
                        return false;
                }
                return true;
            }

            void PrintStack(string[] mass)
            {
                for (int i = 0; i < mass.Length; i++)
                {
                    if (mass[i] != null)
                    {
                        Console.WriteLine($"Элемент №{i} стека:{mass[i]}");
                    }
                }
            }

            void AddToStack(string[] mass, string str)
            {
                try
                {
                    if (!CheckIfStackIsEmpty(mass))
                    {
                        for (int i = mass.Length - 1; i > 0; i--)
                        {
                            if (mass[i] != null)
                            {
                                mass[i + 1] = str;
                                break;
                            }
                        }
                    }
                    if (CheckIfStackIsEmpty(mass))
                    {
                        Console.WriteLine("Стек пуст! На какое место добавить элемент?");
                        int firstIndexOfQueue;
                        while (!(int.TryParse(Console.ReadLine(), out firstIndexOfQueue)) && !(firstIndexOfQueue <= userMasN))
                        {
                            Console.WriteLine("Неверный Ввод индекса элемента! Попробуйте снова:");
                        }
                        mass[firstIndexOfQueue] = str;
                    }
                }
                catch
                {
                    try
                    {
                        for (int i = 0; i < mass.Length; i++)
                        {
                            if (mass[i] != null)
                            {
                                mass[i - 1] = mass[i];
                                mass[i] = null;
                            }
                        }
                        Console.WriteLine("Стек достиг правого края!\nВсе элементы сдвинуты влево!\nПопробуйте добавить элемент снова!");
                    }
                    catch
                    {
                        Console.WriteLine("ОШИБКА ПЕРЕПОЛНЕНИЯ!");
                    }
                }
            }

            void RemoveFromStack(string[] mass, out string str)
            {
                str = null;
                for (int i = mass.Length - 1; i > 0; i--)
                {
                    if (mass[i] != null)
                    {
                        str = mass[i];
                        mass[i] = null;
                        break;
                    }
                }
            }
        }
    }
}
