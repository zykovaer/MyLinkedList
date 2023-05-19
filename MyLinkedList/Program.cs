using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo K;
            MyLinkedList<int> myLinkedList = new MyLinkedList<int>();
            do
            {
                Console.Clear();
                Console.WriteLine("1.Добавление элемента в начало списка");
                Console.WriteLine("2.Добавление элемента в конец списка");
                Console.WriteLine("3.Вывод списка на экран");
                Console.WriteLine("4.Поиск элемента по его значению(возвращает bool)");
                Console.WriteLine("5.Поиск элемента по номеру(возвращает значение)");
                Console.WriteLine("6.Добавление элемента перед заданным");
                Console.WriteLine("7.Добавление элемента после заданного");
                Console.WriteLine("8.Удаление элемента из начала списка");
                Console.WriteLine("9.Удаление элемента из конца списка");
                Console.WriteLine("0.Удаление элемента перед заданным");
                Console.WriteLine("A.Удаление элемента после заданного");
                Console.WriteLine("S.Вставить после каждого элемента, занимающего четную позицию в списке, новый элемент Е1.\n\tПервый элемент имеет значение позиции равный 0");
                Console.WriteLine("D.Создать новый список L, содержащий элементы списков L1 и L2, \n\tчередующиеся между собой (если списки L1 и L2 одинаковой длины)");
                Console.WriteLine("Esc. Выход из программы");
                Console.WriteLine(myLinkedList);
                K = Console.ReadKey();
                Console.WriteLine();
                try
                {
                    switch (K.Key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            myLinkedList.AddFirst(Inpiut("Введите значение: "));
                            break;
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            myLinkedList.AddLast(Inpiut("Введите значение: "));
                            break;
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            Console.WriteLine(myLinkedList);
                            break;
                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4:
                            Console.WriteLine(
                                myLinkedList.Contains(
                                    Inpiut("Введите искомое значение: ")));
                            break;
                        case ConsoleKey.D5:
                        case ConsoleKey.NumPad5:
                            Console.WriteLine(
                                myLinkedList.Search(
                                    Inpiut("Введите номер значения: ")));
                            break;
                        case ConsoleKey.D6:
                        case ConsoleKey.NumPad6:
                            myLinkedList.AddBefore(
                                Inpiut("Введите значение: "),
                                Inpiut("Введите индекс: "));
                            break;
                        case ConsoleKey.D7:
                        case ConsoleKey.NumPad7:
                            myLinkedList.AddAfter(
                                Inpiut("Введите значение: "),
                                Inpiut("Введите индекс: "));
                            break;
                        case ConsoleKey.D8:
                        case ConsoleKey.NumPad8:
                            Console.WriteLine(
                                myLinkedList.PopFirst());
                            break;
                        case ConsoleKey.D9:
                        case ConsoleKey.NumPad9:
                            Console.WriteLine(
                                myLinkedList.PopBack());
                            break;
                        case ConsoleKey.D0:
                        case ConsoleKey.NumPad0:
                            Console.WriteLine(
                                myLinkedList.PopBefore(
                                    Inpiut("Введите индекс: ")));
                            break;
                        case ConsoleKey.A:
                            Console.WriteLine(
                                myLinkedList.PopAfter(
                                    Inpiut("Введите индекс: ")));
                            break;
                        case ConsoleKey.S:
                            myLinkedList.InsertAfterEven(
                                Inpiut("Введите значение: "));
                            break;
                        case ConsoleKey.D:
                            Console.WriteLine("Введите элементы первого списка через пробел");
                            MyLinkedList<int> myLinkedList1 = new MyLinkedList<int>();
                            foreach (string item in Console.ReadLine().Split(' '))
                            {
                                myLinkedList1.AddLast(int.Parse(item));
                            }

                            Console.WriteLine("Введите элементы второго списка через пробел");
                            MyLinkedList<int> myLinkedList2 = new MyLinkedList<int>();
                            foreach (string item in Console.ReadLine().Split(' '))
                            {
                                myLinkedList2.AddLast(int.Parse(item));
                            }

                            myLinkedList = myLinkedList1 + myLinkedList2;
                            break;
                        case ConsoleKey.F:
                            break;
                        case ConsoleKey.G:
                            break;
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;
                        default: Console.WriteLine("Request not processed"); break;
                    }
                    System.Threading.Thread.Sleep(2000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    System.Threading.Thread.Sleep(2000);
                }
            }
            while (K.Key != ConsoleKey.Escape);

        }
        static int Inpiut(string message)
        {
            int N = 0;
            while (true)
            {
                try
                {
                    Console.Write(message);
                    N = int.Parse(Console.ReadLine());

                    if (N < 1) throw new Exception("Такого не может быть!!!\n");
                    return N;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
