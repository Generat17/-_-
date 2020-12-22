using System;
using System.Collections.Generic;
using System.Text;

namespace lab6
{
    partial class Program
    {
        public class MyTestClass : IComparable
        {
            // Конструктор по умолчанию. По умолчанию gender = женский
            public MyTestClass() { Name = null; Age = null; Gender = false; }

            // Конструктор с 3-мя параметрами
            public MyTestClass(string Name, string Age, bool Gender) { this.Name = Name; this.Age = Age; this.Gender = Gender; }

            // Поле №1 - имя
            public string Name { get; set; }

            // Поле №2 - возраст
            [My("Возраст человека")]
            public string Age { get; set; }

            // Поле №3 - пол ( false - жен., true - муж. )
            [My("Пол человека")]
            public bool Gender { get; set; }

            public void GetInfo()
            {
                Console.WriteLine("Имя: {0}\nВозраст: {1}\nПол: {2}",

                    Name ?? "-",
                    Age ?? "-",
                    Gender ? "мужской" : "женский"
                    );
            }

            public int YearOfBirth (int age, int currentYear)
            {
                return currentYear - age;

            }

            public int CompareTo(object obj)
            {
                return 0;
            }
        }
    }
}
