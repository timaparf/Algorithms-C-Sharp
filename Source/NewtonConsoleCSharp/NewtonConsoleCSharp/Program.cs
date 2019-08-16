using System;

namespace NewtonConsoleCSharp
{
    class Program
    {
        static double func(double x)
        {
            return x + Math.Pow(x, 1 / 2) + Math.Pow(x, 1 / 3) + Math.Pow(x, 1 / 4) - 5; ;
        }

        static double funcFirstDerivative(double x) // производная
        {
            return 1 + (1/(2*Math.Sqrt(x))) + (1 / (3 * Math.Pow(x, 2/3))) + (1 / (4 * Math.Pow(x, 3 / 4)));
        }

        static double funcSecondDerivative(double x) // Друга похідна
        {
            return -(((36*Math.Pow(x, 5/12))+(32*Math.Pow(x, 1/4))+(27*Math.Pow(x, 1/6)))/(144*x*Math.Pow(x, 11/12)));

        }

        static void Main(string[] args)
        {
            double a = -1000;
            double b = 10000;
            double eps = 0.000001;
            Newton(a, b, eps);
        }

        //Рекурсивный вызов метода Ньютона
        static void Newton(double a, double b, double eps)
        {
            double x = 0;
            double x1 = 0;
            if (func(a) * funcSecondDerivative(a) > 0)
                x = a; 
            else
                x = b;
            do
            {
                x1 = x;
                x = x - (func(x) / funcFirstDerivative(x));
                Console.WriteLine(x);
            } while (Math.Abs(x - x1) > eps);
            Console.WriteLine("Корінь: ", x);
        }
    }
}
