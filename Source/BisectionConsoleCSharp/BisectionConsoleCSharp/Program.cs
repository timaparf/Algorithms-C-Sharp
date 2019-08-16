using System;

namespace Bisection
{
    class Program
    {
        static double f(double x)
        {
            return x + Math.Pow(x, 1 / 2) + Math.Pow(x, 1 / 3) + Math.Pow(x, 1 / 4) - 5;
        }

        static void Bisection(double a, double b, double eps)
        {
            double c = 0;
            double fa, fb, fc;
            int lich = 0;
            fa = f(a);
            fb = f(b);
            c = (a + b) / 2;

            if (f(c) == 0)
            {
                lich++;
                Console.WriteLine("Знайдено корiнь x={0}, за N={1} подiл(и)(iв)!", c, lich);
            }
            
            else if (fa == 0)
            {
                Console.WriteLine("Знайдено корiнь x={0}, за N={1} подiл(и)(iв)!", a, lich);
            }

            else if (fb == 0)
            {
                Console.WriteLine("Знайдено корiнь x={0}, за N={1} подiл(и)(iв)!", b, lich);
            }

            else
            {
                do
                {
                    fa = f(a);
                    fb = f(b);
                    c = (a + b) / 2;
                    fc = f(c);

                    if ((f(c) == 0))
                    {
                        lich++;
                        Console.WriteLine("|k =\t\t|{0}", lich);
                        Console.WriteLine("|Ak =\t\t|{0}", a);
                        Console.WriteLine("|Xk =\t\t|{0}", c);
                        Console.WriteLine("|Bk =\t\t|{0}", b);
                        Console.WriteLine("| |Bk - Ak| =\t|{0}", Math.Abs(b - a));
                        Console.WriteLine("|F(Xk) =\t|{0}", f(c));
                        Console.WriteLine();
                        break;
                    }
                    else if (fa * fc < 0)
                    {
                        b = c;
                        lich++;
                        Console.WriteLine("|k =\t\t|{0}", lich);
                        Console.WriteLine("|Ak =\t\t|{0}", a);
                        Console.WriteLine("|Xk =\t\t|{0}", c);
                        Console.WriteLine("|Bk =\t\t|{0}", b);
                        Console.WriteLine("| |Bk - Ak| =\t|{0}", Math.Abs(b - a));
                        Console.WriteLine("|F(Xk) =\t|{0}", f(c));
                        Console.WriteLine();
                    }
                    else
                    {
                        a = c;
                        lich++;
                        Console.WriteLine("|k =\t\t|{0}", lich);
                        Console.WriteLine("|Ak =\t\t|{0}", a);
                        Console.WriteLine("|Xk =\t\t|{0}", c);
                        Console.WriteLine("|Bk =\t\t|{0}", b);
                        Console.WriteLine("| |Bk - Ak| =\t|{0}", Math.Abs(b - a));
                        Console.WriteLine("|F(Xk) =\t|{0}", f(c));
                        Console.WriteLine();
                    }


                } while (Math.Abs(b - a) > eps);
                Console.WriteLine("Знайдено корiнь x={0}, за N={1} подiл(и)(iв)!", c, lich);
            }

        }
        static void Main()
        {
            double a = -1000000;
            double b = 1000000;
            double eps = Math.Pow(10, -4);
            Bisection(a, b, eps);
        }
    }
}