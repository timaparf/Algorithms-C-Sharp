using System;

namespace Bisection
{
    class Program
    {
        static public double InputDouble(string s)
        {
            double input = 0;
            string cont = "";
            do
            {
                try
                {
                    cont = "";
                    Console.WriteLine(s);
                    input = double.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "Again?");
                    cont = Console.ReadLine();
                }
            } while (cont == "yes");
            return input;
        }

        static double f(double x)//Задана функція
        {
            return x + Math.Pow(x, 1 / 2) + Math.Pow(x, 1 / 3) + Math.Pow(x, 1 / 4) - 5;
        }

        static void Bisection(double eps)//Метод розв'язання рівняння методом бісекції
        {
            double a = 0;
            double b = 0;
            do
            {
                a = InputDouble("Введіть першу точку проміжку: ");
                b = InputDouble("Введіть другу точку проміжку: ");
                if (f(a) * f(b) > 0)
                {
                    Console.WriteLine("На цьому проміжку не має коренів.");
                }
            } while (f(a) * f(b) > 0);
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

                } while ((Math.Abs(a-b)) > eps || f(c) > eps);
                Console.WriteLine("Знайдено корiнь x={0}, за N={1} подiл(и)(iв)!", c, lich);
            }

        }

        static double funcFirstDerivative(double x) // Перша похідна
        {
            return 1 + (1 / (2 * Math.Sqrt(x))) + (1 / (3 * Math.Pow(x, 2.0 / 3))) + (1 / (4 * Math.Pow(x, 3.0 / 4)));
        }

        static double funcSecondDerivative(double x) // Друга похідна
        {
            return -(((36 * Math.Pow(x, 5.0 / 12)) + (32 * Math.Pow(x, 1.0 / 4)) + (27 * Math.Pow(x, 1.0 / 6))) / (144 * x * Math.Pow(x, 11.0 / 12)));

        }

        static void Newton(double eps)//Метод розв'язання рівняння методом Ньтона
        {
            double a = 0;
            double b = 0;
            int lich=0;
            do
            {
                a = InputDouble("Введіть першу точку проміжку: ");
                b = InputDouble("Введіть другу точку проміжку: ");
                if (((funcSecondDerivative(a))*funcSecondDerivative(b)) < 0 || f(a) * f(b) > 0)
                {
                    Console.WriteLine("На цьому проміжку не має коренів.");
                }
            } while(((funcSecondDerivative(a)) * funcSecondDerivative(b)) < 0 || f(a) * f(b) > 0);
            Console.WriteLine("Метод Ньтона");
            double x = 0;
            double x1 = 0;
            if (f(a) * funcSecondDerivative(a) > 0)
                x = a;
            else 
                x = b;
            do
            {
                x1 = x;
                x = x - (f(x) / funcFirstDerivative(x));
                lich++;
                Console.WriteLine("|k =\t\t|{0}\t\t|", lich);
                Console.WriteLine("| |Xk - X(k-1)| =\t|{0}", Math.Abs(x - x1));
                Console.WriteLine("|x =\t\t|{0}\t\t|", x);
                Console.WriteLine();
                /*if ((((funcSecondDerivative(x) * f(x)) <= 0 /*|| ((funcSecondDerivative(x) * f(x))) >= (funcFirstDerivative(x) * funcFirstDerivative(x)))))
                {
                    Console.WriteLine("Метод розбігається на заданому проміжку.");
                    Newton(eps);
                }*/

            } while (Math.Abs(x - x1) > eps);
            Console.WriteLine("Знайдено корiнь x={0}, за N={1} подiл(и)(iв)!", x, lich);
        }

        static void Main()
        {
            double eps = Math.Pow(10, -4);
            Bisection(eps);
            Newton(eps);
        }
    }
}