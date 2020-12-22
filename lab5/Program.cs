using System;

namespace _3lab5
{
    class Program
    {
        static void delimiter(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine(" ");
        }

        public static int LevenshteinDistance(string str1, string str2)
        {
            if ((str1 == null && str2 == null) || (str1 == str2)) return 0;
            if (str1 == null || str2 == null) throw new ArgumentNullException("Одна из строк пустая!\n");

            int[,] matrix = new int[str1.Length + 1, str2.Length + 1];

            for (int i = 0; i <= str1.Length; i++)
            {
                matrix[i, 0] = i;
            }
            for (int j = 0; j <= str2.Length; j++)
            {
                matrix[0, j] = j;
            }

            for (int i = 1; i <= str1.Length; i++)
            {
                for (int j = 1; j <= str2.Length; j++)
                {
                    int d = 1;
                    if (str1[i - 1] == str2[j - 1]) d = 0;
                    matrix[i, j] = Math.Min(Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1), matrix[i - 1, j - 1] + d);

                }
            }
            return matrix[str1.Length, str2.Length];
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Алиев Тимур РТ5-31Б\n");
            delimiter(100);
            string string1, string2;
            Console.WriteLine("Введите 1 строку: ");
            string1 = Console.ReadLine();
            Console.WriteLine("Введите 2 строку: ");
            string2 = Console.ReadLine();
            Console.WriteLine("Расстояние Левенштейна для данных строк: {0}", LevenshteinDistance(string1, string2));
        }
    }
}
