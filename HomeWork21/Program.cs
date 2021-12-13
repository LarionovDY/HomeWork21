using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork21
{
    //Имеется пустой участок земли(двумерный массив) и план сада, который необходимо реализовать.
    //Эту задачу выполняют два садовника, которые не хотят встречаться друг с другом.
    //Первый садовник начинает работу с верхнего левого угла сада и перемещается слева направо, сделав ряд, он спускается вниз.
    //Второй садовник начинает работу с нижнего правого угла сада и перемещается снизу вверх, сделав ряд, он перемещается влево.
    //Если садовник видит, что участок сада уже выполнен другим садовником, он идет дальше.Садовники должны работать параллельно. 
    //Создать многопоточное приложение, моделирующее работу садовников.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размеры земельного участка(не более 20х20):");
            int gardenLength = ReadValue("Длина:");
            int gardenWidth = ReadValue("Ширина:");
            Garden garden = new Garden(gardenLength, gardenWidth);
            int speed1 = SetGardenerSpeed(1);
            int speed2 = SetGardenerSpeed(2);
            ParameterizedThreadStart threadStart1 = new ParameterizedThreadStart(garden.Gardener1);
            Thread thread1 = new Thread(threadStart1);
            ParameterizedThreadStart threadStart2 = new ParameterizedThreadStart(garden.Gardener2);
            Thread thread2 = new Thread(threadStart2);
            thread1.Start(speed1);
            thread2.Start(speed2);
            Console.SetWindowSize(gardenLength * 9, gardenWidth * 3);
            while (!garden.Gardener1_Status || !garden.Gardener2_Status)
            {
                Print(garden.District);
            }
            Console.ReadKey();
        }
        public static void Print(char[,] Array)     //вывод на консоль условного изображения сада с обозначением выполнения садовниками участков 
        {
            Console.Clear();
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    if (Array[i, j] == '#')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if (Array[i, j] == '*')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (Array[i, j] == '.')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    }
                    Console.Write($"\t{Array[i, j]}");
                }
                Console.WriteLine('\n');
            }
            Thread.Sleep(500);

        }
        static int ReadValue(string text)   //метод проверяющий корректность ввода данных
        {
            int value;
            while (true)
            {
                Console.WriteLine(text);
                if (Int32.TryParse(Console.ReadLine(), out value) && value <= 20 && value > 0)
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Ввод некорректен");
                }
            }
        }
        static int SetGardenerSpeed(int count)      //метод задающий скорость выполнения работ садовником
        {
            Console.WriteLine($"Выберите скорость работы садовника №{count}:\n1 - прокрастинатор\n2 - трудяга\n3 - стахановец");
            while (true)
            {
                ConsoleKey consolekey = Console.ReadKey().Key;
                switch (consolekey)
                {
                    case ConsoleKey.D1:
                        return 2000;
                    case ConsoleKey.D2:
                        return 1000;
                    case ConsoleKey.D3:
                        return 500;
                    case ConsoleKey.NumPad1:
                        return 2000;
                    case ConsoleKey.NumPad2:
                        return 1000;
                    case ConsoleKey.NumPad3:
                        return 500;
                    default:
                        Console.WriteLine("Вы ввели недопустимый символ");
                        break;
                }
            }
        }       
    }
}
