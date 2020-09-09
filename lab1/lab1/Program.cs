using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            double A = 0, B = 0, C = 0, D = 0, t1 = 0, t2 = 0, x1 = 0, x2 = 0, x3 = 0, x4 = 0;
            bool check = false;

            Console.WriteLine("Алиев Тимур РТ5-31Б");
            if (args.Length == 0)
            {
                Console.WriteLine("Введите коэффициенты A, B, C");
                do
                {
                    if (check)
                    {
                        Console.WriteLine("Ошибка. Повторите ввод!");
                    }
                    check = false;
                    if (!double.TryParse(Console.ReadLine(), out A)) { check = true; }
                    if (!double.TryParse(Console.ReadLine(), out B)) { check = true; }
                    if (!double.TryParse(Console.ReadLine(), out C)) { check = true; }
                } while (check);
            }
            else
            {
                check = double.TryParse(args[0], out A);
                check = double.TryParse(args[1], out B);
                check = double.TryParse(args[2], out C);
                if (!check)
                {
                    Console.WriteLine("Неверные параметры командной строки");
                    return;
                }
            }

            D = B * B - 4 * A * C;
            if (D < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Уравнение не имеет действительных корней");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            else
            {
                t1 = ((-B + Math.Sqrt(D)) / (2 * A));
                t2 = ((-B - Math.Sqrt(D)) / (2 * A));
            }

            Console.ForegroundColor = ConsoleColor.Green;

            if (t1 >= 0)
            {
                if (t1 > 0)
                {
                    x1 = Math.Sqrt(t1);
                }
                x2 = -x1;
                Console.WriteLine($"x1 = {x1}; x2 = {x2};");
            }

            if (t2 >= 0)
            {
                if (t2 > 0)
                {
                    x3 = Math.Sqrt(t2);
                }
                x4 = -x3;
                Console.WriteLine($"x3 = {x3}; x4 = {x4};");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}
