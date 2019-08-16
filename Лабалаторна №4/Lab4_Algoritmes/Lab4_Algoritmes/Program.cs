using System;

namespace Lab4_Algoritmes
{
    class Program
    {
        static double[] ArrX = { 0.88, 1.68, 2.3, 2.8, 3.5, 4.11, 4.78, 5, 6.5, 7.2, 8.9, 9.3, 9.33, 9.89, 10.2 };
        static double[] ArrY = {0.59490, -0.10877, -0.61806, -0.80887, -0.80546, -0.53678, 0.06751, 0.27987,
                                                    0.82859, 0.57152, -0.76138, -0.83725, -0.83904, -0.77941, -0.65506 };

        static double[] x_Arr;
        static double[] y_Arr;

        static void CreatePointsArray(double a = 1, double b = 10, double h = 0.1)
        {
            int length = (int)((b-a) / h);
            x_Arr = new double[length];
            y_Arr = new double[length];
            for (int i = 0; i<length; i++)
            {
                x_Arr[i] = a + h;
                y_Arr[i] = Function(x_Arr[i]);
                a += h;
            }


        }

        static double GlobalInterpolation(double x)
        {
            int num = 15;
            double LFunc = 0;
            for (int i = 0; i< num; i++)
            {
                double Lnum = 1, Lden = 1;
                for(int j=0; j<num; j++)
                {
                    if(i!=j)
                    {
                        Lnum *= (x - ArrX[j]);
                        Lden *= (ArrX[i] - ArrX[j]);
                    }
                }
                LFunc += (Lnum / Lden) * ArrY[i];
            }

            return LFunc;
        }

        static int FindMinInArray(double x)
        {
            int i = 0;
            int min = 0;
            
            for (i = 0; i < ArrX.Length-4; i++)
                if ((Math.Abs(ArrX[min] - x) + Math.Abs(ArrX[min + 1] - x) + Math.Abs(ArrX[min + 2] - x) >
                   (Math.Abs(ArrX[i + 1] - x) + Math.Abs(ArrX[i + 2] - x) + Math.Abs(ArrX[i + 3] - x))))
                    min = i + 1;
            return min;
        }

        static double LocalInterpolation(double x)
        {
            int min = FindMinInArray(x);

            double Inter1 = (ArrY[min] * (((x - ArrX[min+1]) * (x - ArrX[min+2])) /
                                            ((ArrX[min] - ArrX[min+1]) * (ArrX[min] - ArrX[min+2]))));
            double Inter2 = (ArrY[min+1] * (((x - ArrX[min]) * (x - ArrX[min+2])) /
                                            ((ArrX[min+1] - ArrX[min]) * (ArrX[min+1] - ArrX[min+2]))));
            double Inter3 = (ArrY[min+2] * (((x - ArrX[min]) * (x - ArrX[min+1])) /
                                            ((ArrX[min+2] - ArrX[min]) * (ArrX[min+2] - ArrX[min+1]))));

            return Inter1+Inter2+Inter3;
        }

        /*static double LocalInterpolation(double x)
        {
            int min = FindMinInArray(x);
            double L = 0;
            for (int i = min; i <= min + 3; i++)
            {
                double Lnum = 1, Lden = 1;
                for (int j = min; j <= min + 3; j++)
                {
                    if (i != j)
                    {
                        Lnum *= (x - ArrX[j]);
                        Lden *= (ArrX[i] - ArrX[j]);
                    }

                }
                L += (Lnum / Lden) * ArrY[i];
            }
            return L;
        }*/

        static double Function(double x)
        {
            return Math.Sin(Math.Cos(x));
        }

        static double FirstDer(double x)
        {
            return -Math.Sin(x) * Math.Cos(Math.Cos(x));
        }

        static double SecondDer(double x)
        {
            return (-Math.Sin(Math.Cos(x)) * (Math.Sin(x) * Math.Sin(x))) - Math.Cos(Math.Cos(x)) * Math.Cos(x);
        }

        static void InterpolationValuesPrint()
        {
            Console.WriteLine("X\t| Y Formuala\t| Y Global\t| Y Local\t|");
            for (int i = 0; i < x_Arr.Length; i++)
            {
                Console.WriteLine("{0:f1}\t| {1:f4}\t| {2:f4}\t| {3:f4}\t| ", x_Arr[i], Function(x_Arr[i]),
                                               GlobalInterpolation(x_Arr[i]), LocalInterpolation(x_Arr[i]));
            }
        }

        static void DifferentiationValuesPrint()
        {
            Console.WriteLine("X\t| Y' Formula\t| Y'' Formula\t|");
            for (int i = 0; i < x_Arr.Length; i++)
            {
                Console.WriteLine("{0:f1}\t| {1:f4}\t| {2:f4}\t| ", x_Arr[i], FirstDer(x_Arr[i]),
                                               SecondDer(x_Arr[i]));
            }
        }

        static void Main()
        {
            CreatePointsArray();
            Console.WriteLine(Function(5));
            Console.WriteLine(GlobalInterpolation(5));
            Console.WriteLine(LocalInterpolation(5));
            InterpolationValuesPrint();
            Console.WriteLine();
            DifferentiationValuesPrint();

        }
    }
}
