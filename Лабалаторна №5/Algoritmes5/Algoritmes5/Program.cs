using System;
namespace Algoritmes5
{ 
    class Program
    {
        static public void IFunction()
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("| x\t| f(x)\t\t| ");
            Console.WriteLine("-------------------------");
            double hx = 0.1;
            for (double x = 0; x <= 1; x = x + hx)
            {
                Console.WriteLine($"|{x}\t| {Integral(0, x, Runge(0,x)):f5}\t| ");
                Console.WriteLine("-------------------------");
            }

        }
        static public double Function(double t)
        {
            return (Math.Log(1 + t, Math.E)) / (1 + (t * t));
        }
        static public double Integral(double a, double b, double h)
        {
            double I = 0;
            double Fxi = 0;
            for(double x = a + h; x < b; x = x + h)
            {
                double f = 2 * Function(x);
                Fxi += f;
            }
            I = (h / 2) * (Function(a) + Function(b) + Fxi);
            return I;
        }
        static public double Runge(double a, double b)
        {
            double h = (a + b) / 5;
            double I = 0;
            double Ih = 0;
            do
            {
                I = Integral(a, b, h);
                Console.WriteLine($"| Integral I: {I:f6}\t|");
                h = h / 2;
                Ih = Integral(a, b, h);
                Console.WriteLine($"| Integeal Ih: {Ih:f6}\t|");
                Console.WriteLine($"| (Ih - I)/3: {Math.Abs((Ih - I)/3):f6}\t|");
                Console.WriteLine($"| h: {h:f6}\t\t|");
                Console.WriteLine("-------------------------");

            } while (Math.Abs((Ih - I)/3) > Math.Pow(10, -4));
            Console.WriteLine("-------------------------");
            return h;
        }
        static void Main()
        {
            Console.WriteLine("Program by T. Parfeniuk 2019");
            IFunction();
        }
    }
}
