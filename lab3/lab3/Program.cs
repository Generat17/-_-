using System;
using System.Collections.Generic;

namespace lab3
{
    abstract class geom_fig
    {
        public string name;
        public double area;
    }


    class Cube : geom_fig, IComparable
    {
        private double length;
        public Cube (double l)
        {
            length = l;
            name = "cube";
            area = l * l;
        }

        public int CompareTo(object o)
        {
            geom_fig p = o as geom_fig;
            if (p != null)
                return this.area.CompareTo(p.area);
            else
                throw new Exception("Невозможно сравнить два объекта.");

        }
    }

    class Circle : geom_fig, IComparable
    {
        private double radius;
        public Circle (double r)
        {
            radius = r;
            name = "circle";
            area = r * r * Math.PI;
        }

        public int CompareTo(object o)
        {
            geom_fig p = o as geom_fig;
            if (p != null)
                return this.area.CompareTo(p.area);
            else
                throw new Exception("Невозможно сравнить два объекта.");

        }
    }

    class Triangle : geom_fig, IComparable
    {
        private double length, height;
      
        public Triangle(double l, double h)
        {
            name = "triangle";
            length = l;
            height = h;
            area = l * h;
        }

        public int CompareTo(object o)
        {
            geom_fig p = o as geom_fig;
            if (p != null)
                return this.area.CompareTo(p.area);
            else
                throw new Exception("Невозможно сравнить два объекта.");

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle1 = new Triangle(2, 6);
            Circle circle1 = new Circle(2);
            Cube cube1 = new Cube(2);
            Triangle triangle2 = new Triangle(3, 6);
            Circle circle2 = new Circle(3);
            Cube cube2 = new Cube(1);

            List< geom_fig > fig = new List<geom_fig>{ triangle1, triangle2, cube1, cube2, circle1, circle2 };
            fig.Sort();

            foreach(geom_fig p in fig)
            {
                Console.WriteLine($"name = {p.name}, area = {p.area}");
            }
        }
    }
}
