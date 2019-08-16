using System;


namespace Algoritmes_2
{
    class Program
    {
        
        static double f1(double x)
        {
            double y = Math.Sin(x + 1) - 1.2;
            return y;
        }

        static double f2(double y)
        {
            double x = 0.5 * (2 - Math.Cos(y));
            return x;
        }

        static bool Test(double x, double y) //Перевірка умови збіжності
        {
            bool test;
            if ((Math.Abs(Math.Cos(x + 1))) < 1 && (Math.Abs((0.5 * (Math.Sin(x))))) < 1)//кубічна норма
                test = true;
            else test = false;
            return test;
        }

        static void IterationMethod(double eps) //Метод простих ітерацій
        {
            bool cont;
            double x = 0.3;
            double y = 0.3;
            cont = Test(x, y);
            if (cont == true)
            {
                double x0;
                double y0;
                int k = 0;
                do
                {
                    cont = Test(x,y);
                    x0 = x;
                    y0 = y;
                    x = f2(y0);
                    y = f1(x0);
                    k++;
                    Console.WriteLine("|k =\t\t\t|{0}\t\t", k);
                    Console.WriteLine("| Xk =\t\t\t|{0}", x);
                    Console.WriteLine("| Yk =\t\t\t|{0}", y);
                    Console.WriteLine("| |Xk - X(k-1)| =\t|{0}", Math.Abs(x - x0));
                    Console.WriteLine("| |Yk - Y(k-1)| =\t|{0}", Math.Abs(y - y0));
                    Console.WriteLine("| f1 (x,y) =\t\t|{0}", Math.Sin(x+1)-y-1.2);
                    Console.WriteLine("| f2 (x,y) =\t\t|{0}", (2*x) + Math.Cos(y)-2);
                    Console.WriteLine();

                    if (cont == false)
                        Console.WriteLine("Розбігаєтсья.");
                } while (Math.Abs((x - x0)) + Math.Abs((y - y0)) > eps && cont == true); //Перша(октаедрична норма)
                Console.WriteLine(x);
                Console.WriteLine(y);
            }
            else
                Console.WriteLine("Метод розбігається.");
        }

        static void Main()
        {
            double eps = Math.Pow(10, -4);
            IterationMethod(eps);
        }
    }
}