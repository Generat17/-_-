using System;
using System.Reflection;

namespace lab6
{
    // Делегат производящий математические операции над двумя числами
    delegate string MathOperation(double num_1, double num_2);
    partial class Program
    {
        // Часть 1

        // Метод сложения (соответствующий нашему делегату)
        static string Addition(double num_1, double num_2)
        {
            return (num_1 + num_2).ToString();
        }

        // Метод вычитания (соответствующий нашему делегату)
        static string Subtraction(double num_1, double num_2)
        {
            return (num_1 - num_2).ToString();
        }

        // Метод деления (соответствующий нашему делегату)
        static string Division(double num_1, double num_2)
        {
            return (num_1 / num_2).ToString();
        }

        // Метод с делегатным параметром
        static string MethodMathOperation(double num_1, double num_2, MathOperation operation)
        {
            return operation(num_1, num_2);
        }

        // Метод принимающий в качестве одного из параметров обобщенный делегат Func
        static string MethodMathOperationFunc(double num_1, double num_2, Func<double, double, string> operation)
        {
            return operation(num_1, num_2);
        }

        // Часть 2

        // Проверка, что у свойства есть атрибут заданного типа
        public static bool GetPropertyAttribute(PropertyInfo checkType, Type attributeType, out object attribute)
        {
            bool Result = false;
            attribute = null;

            //Поиск атрибутов с заданным типом
            var isAttribute = checkType.GetCustomAttributes(attributeType, false);
            if (isAttribute.Length > 0)
            {
                Result = true;
                attribute = isAttribute[0];
            }

            return Result;
        }

        // Получение информации о текущей сборке

        static void AssemblyInfo()
        {
            Console.WriteLine("Вывод информации о сборке:");
            Assembly i = Assembly.GetExecutingAssembly();
            Console.WriteLine("Полное имя:" + i.FullName);
            Console.WriteLine("Исполняемый файл:" + i.Location);
        }

        // Получение информации о типе
        static void TypeInfo()
        {
            MyTestClass obj = new MyTestClass();
            Type t = obj.GetType();

            //другой способ
            //Type t = typeof(MyTestClass);

            Console.WriteLine("\nИнформация о типе:");
            Console.WriteLine("Тип " + t.FullName + " унаследован от " + t.BaseType.FullName);
            Console.WriteLine("Пространство имен " + t.Namespace);
            Console.WriteLine("Находится в сборке " + t.AssemblyQualifiedName);

            Console.WriteLine("\nКонструкторы:");
            foreach (var x in t.GetConstructors())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nМетоды:");
            foreach (var x in t.GetMethods())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nСвойства:");
            foreach (var x in t.GetProperties())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nПоля данных (public):");
            foreach (var x in t.GetFields())
            {
                Console.WriteLine(x);
            }

        }

        // Пример использования метода InvokeMember
        static void InvokeMemberInfo()
        {
            Type t = typeof(MyTestClass);
            Console.WriteLine("\nВызов метода:");
            MyTestClass fi = (MyTestClass)t.InvokeMember(null, BindingFlags.CreateInstance, null, null, new object[] { });

            //Параметры вызова метода
            object[] parameters = new object[] { 19, 2020};
            //Вызов метода
            object Result = t.InvokeMember("YearOfBirth", BindingFlags.InvokeMethod, null, fi, parameters);
            Console.WriteLine("YearOfBirth(20, 2020) = {0}", Result);
        }

        // Работа с атрибутами
        static void AttributeInfo()
        {
            Type t = typeof(MyTestClass);
            Console.WriteLine("\nСвойства, помеченные атрибутом:");
            foreach (var x in t.GetProperties())
            {
                object attrObj;
                if (GetPropertyAttribute(x, typeof(MyAttribute), out attrObj))
                {
                    MyAttribute attr = attrObj as MyAttribute;
                    Console.WriteLine(x.Name + " - " + attr.Description);
                }
            }
        }

        static void Main(string[] args)
        {           
            Console.WriteLine("Алиев Тимур РТ5-31Б");

            // Тестирование первой части лабораторной работы
            Console.WriteLine("----------------------------------------------------Первая часть----------------------------------------------------");

            double x = 5, y = 2;
            Console.WriteLine($"x = {x}, y = {y}");

            // Создание экземпляра нашего делегата
            MathOperation add;
            // Присваевыем в него нужный нам метод
            add = Addition;
            // И вызываем созанный нами объект делегата передав в него параметры
            Console.WriteLine($"x + y = {add(x,y)}");

            // Вызваем метод, который принимает делегат
            Console.WriteLine($"x + y = {MethodMathOperation(x, y, Addition)}");
            Console.WriteLine($"x - y = {MethodMathOperation(x, y, Subtraction)}");

            // Передадим в этот же метод Лямбда-выражение
            Console.WriteLine($"x * y = {MethodMathOperation(x, y, (x, y) => (x * y).ToString())}");

            // Обобщенный делегат Func
            Console.WriteLine($"x / y = {MethodMathOperationFunc(x, y, Division)}");

            // Тестирование второй части лабораторной работы
            Console.WriteLine("----------------------------------------------------Вторая часть----------------------------------------------------");

            // Создаю экземпляр тестового класса (MyTestClass), третьим параметром в конструктор передаю bool значение (true - муж., false - жен.)
            MyTestClass person_1 = new MyTestClass("Клава", "19", false);
            MyTestClass person_2 = new MyTestClass("Жорик", "15", true);
            person_1.GetInfo();

            Console.WriteLine();

            AssemblyInfo();
            TypeInfo();
            InvokeMemberInfo();
            AttributeInfo();

        }
    }
}
