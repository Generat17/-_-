using System;

namespace lab2
{   
    abstract class GeometricFigure
    {
        // Название фигуры
        public string name;

        // Вычисление площади фигуры
        virtual public double Area(){
            return(0);
        }
    }

    public interface IPrint
    {
        public void Print();
    }

    class Square: GeometricFigure, IPrint
    {
        private double length;
        public Square(double l)
        {
            name = "Square";
            length = l;
        }

        public override double Area()
        {
            return (length*length);
        }

        public override string ToString() {
            return ($"name - {name}, length = {length}, area = {this.Area()}");
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }

    class Circle : GeometricFigure, IPrint
    {
        private double radius;
        public Circle (double r)
        {
            name = "Circle";
            radius = r;
        }

        public override double Area()
        {
            return (3.14 * radius * radius);
        }

        public override string ToString()
        {
            return ($"name - {name}, radius = {radius}, area = {this.Area()}");
        }

        void IPrint.Print()
        {
            Console.WriteLine(this.Area());
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }

    class Rectangle : GeometricFigure, IPrint
    {
        private double length;
        private double height;
        public Rectangle(double l, double h)
        {
            name = "Rectangle";
            length = l;
            height = h;
        }

        public override double Area()
        {
            return (height * length);
        }

        public override string ToString()
        {
            return ($"name - {name}, length = {length}, height = {height}, area = {this.Area()}");
        }

        void IPrint.Print()
        {
            Console.WriteLine(this.Area());
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(5,4);
            Circle circle = new Circle(5);
            Square square = new Square(6);


            rectangle.Print();
            circle.Print();
            square.Print();
        }
    }
}
