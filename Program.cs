//Реалізувати клас Point (властивості: координати X,Y),
//метод ToString для вивода координат точки, конструктор
//Реалізувати клас Triangle (властивості: масив Point[3]), конструктор
//Клас Triangle повинен реалізувати інтерфейс IEnumerator
//В Main протестіть роботу foreach для об'єкта типу Triangle”
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_Homework_6_1
{
    internal class Program
    {
        class Point
        {
            public int X { get; set; }
            public int Y {  get; set; }
            public Point() { }
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
            public void Input()
            {
                Console.Write("Введіть координату Х: ");
                X = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введіть координату Y: ");
                Y = Convert.ToInt32(Console.ReadLine());
            }
            public override string ToString()
            {
                Console.WriteLine($"Крапка ({X}, {Y})");
                return "Крапка ({X}, {Y})";
            }
        }
        class Triangle : IEnumerator
        {
            Point[] point;
            int curpos = -1;
            public Triangle(int n)
            {
                point = new Point[n];
                for(int i = 0; i < n; i++)
                {
                    point[i]=new Point();
                }

            }
            public Triangle(Point[]p)
            {
                point = new Point[(int)p.Length];
                for(int i = 0;i < p.Length; i++)
                {
                    point[i] = new Point(p[i].X, p[i].Y);
                }
            }
            public void InputPoint()
            {
                for(int i = 0; i < point.Length ; i++)
                {
                    point[i].Input();
                }
            }
            public void ShowToString()
            {
                for(int i = 0; i < point.Length; i++)
                {
                    point[i].ToString();
                }
            }
            public void Reset()//установка в початкову позицію
            {
                curpos = -1;
            }

            public object Current//поточна позиція
            {
                get
                {
                    return point[curpos];
                }
            }
            public bool MoveNext()
            {
                if(curpos < point.Length - 1)//переміщення. Якщо переміщення невдале - повернення на початок.
                {
                    curpos++;
                    return true;
                }
                else
                {
                    this.Reset();
                    return false;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Point [] points = new Point[3];
            for(int i = 0; i < points.Length; i++)
            {
                points[i] = new Point();
                points[i].Input();
            }
            Console.WriteLine("\nВведені крапки з координатами:");
            foreach(Point p in points)
            {
                p.ToString();
            }
            Console.ReadLine();
        }
    }
}
