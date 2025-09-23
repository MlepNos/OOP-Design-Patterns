// Program.cs
using System;

namespace PatternMatchingDemo
{
    class Program
    {
        static void Main()
        {
            Shape s = new Circle(3);

            // Type pattern + property pattern + relational pattern
            double area = s switch
            {
                Circle { Radius: > 0 } c          => Math.PI * c.Radius * c.Radius,
                Rectangle { Width: > 0, Height: > 0 } r => r.Width * r.Height,
                Triangle { A: > 0, B: > 0, C: > 0 } t   => Heron(t.A, t.B, t.C),
                _ => 0
            };
            Console.WriteLine($"Area = {area:0.##}");

            // 'is' pattern with capture + when-guard
            if (s is Circle c2 && c2.Radius is >= 1 and <= 10)
                Console.WriteLine("Smallish circle");

            // Tuple pattern demo
            Console.WriteLine(Quadrant( 3, 4));  // Q1
            Console.WriteLine(Quadrant(-2, 5));  // Q2
            Console.WriteLine(Quadrant( 0, 0));  // Origin
        }

        static double Heron(double a, double b, double c)
        {
            var p = (a + b + c) / 2.0;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        static string Quadrant(int x, int y) => (x, y) switch
        {
            (0, 0)           => "Origin",
            (> 0, > 0)       => "Q1",
            (< 0, > 0)       => "Q2",
            (< 0, < 0)       => "Q3",
            (> 0, < 0)       => "Q4",
            (0, _)           => "Y axis",
            (_, 0)           => "X axis",
        };
    }
}
