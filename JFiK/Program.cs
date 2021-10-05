using System;
using System.Threading;
namespace JFiK
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = new int[5] { 10, 20, -30, 5, 12 };
            //int arr = new int[amount];
            Console.WriteLine("Wybierz opcje [wprowadz cyfre]: \n 1. Odchylenie standardowe \n 2. Mediana szeregu przedzialowego \n\n");
            string amount = Console.ReadLine();
            
            while(!int.TryParse(amount, out int value))
            {
                Console.WriteLine("Nie podano liczby, spróbuj ponownie...");
                amount = Console.ReadLine();
            }
            

            int operation = int.Parse(amount);

            switch (operation)
            {
                case 1: // Interfejs dla odchylenia standardowego
                    Console.WriteLine("\n");
                    Console.WriteLine("Podaj ilość danych do odchylenia standardowego");
                    string arrsize = Console.ReadLine();

                    while(!int.TryParse(arrsize, out int _arrsize))
                    {
                        Console.WriteLine("Nie podano liczby, sprobuj ponownie...");
                        arrsize = Console.ReadLine();
                    }

                    int __arrsize = int.Parse(arrsize);
                    int[] arr = new int[__arrsize];

                    for(int i = 0, j = 1; i < arr.Length; i++, j++)
                    {
                        Console.WriteLine("Podaj liczbe [" + j + "/" + arr.Length + "]");
                        string tempStr = Console.ReadLine();
                            while(!int.TryParse(tempStr, out int _temp))
                                {
                                Console.WriteLine("Nie podano liczby, sprobuj ponownie...");
                                tempStr = Console.ReadLine();
                                }
                        arr[i] = int.Parse(tempStr);
                    }
                    Console.WriteLine("Licze...");
                    System.Threading.Thread.Sleep(1000);

                    Console.WriteLine("Obliczono, twoje odchylenie standardowe dla danych, ktore podales to:");
                    float avg = calculateAverage(arr);
                    calculateDeviation(arr, avg);
                    break;

                case 2:
                    Console.WriteLine("\n");
                    Console.WriteLine("Podaj minimum zakresu dla mediany");
                    string min = Console.ReadLine();
                        while(!int.TryParse(min, out int _min))
                        {
                        Console.WriteLine("Nie podano liczby, sprobuj ponownie...");
                        min = Console.ReadLine();
                        }
                    int __min = int.Parse(min);

                    Console.WriteLine("Podaj maksimum zakresu dla mediany");
                    string max = Console.ReadLine();
                    while (!int.TryParse(max, out int _max))
                    {
                        Console.WriteLine("Nie podano liczby, sprobuj ponownie...");
                        max = Console.ReadLine();
                    }
                    int __max = int.Parse(max);

                    Console.WriteLine("Podaj liczebnosc zakresu dla mediany");
                    string qua = Console.ReadLine();
                    while (!int.TryParse(qua, out int _qua))
                    {
                        Console.WriteLine("Nie podano liczby, sprobuj ponownie...");
                        qua = Console.ReadLine();
                    }
                    int __qua = int.Parse(qua);
                    Console.WriteLine("Licze...");
                    Thread.Sleep(1000);

                    calculateMediana(__min, __max, __qua);
                    break;
            }
            
        }

        // Liczenie sredniej
        static float calculateAverage(int[] tab)
        {
            float average = 0;
            for(int i = 0; i < tab.Length; i++)
            {
                average += tab[i];
            }
            average /= tab.Length;
            return average;
        }

        // Liczenie odchylenia standardowego
        static void calculateDeviation(int[] tab, float average)
        {
            float[] temptab = new float[tab.Length];
            float deviationValue = 0.0f;
            for (int i = 0; i < tab.Length; i++)
            {
                temptab[i] = tab[i] - average;
                    if (temptab[i] < 0) temptab[i] *= -1;
            }

            for(int i = 0; i < tab.Length; i++)
            {
                deviationValue += temptab[i];
            }

            deviationValue /= tab.Length;

            Console.WriteLine(deviationValue);
        }

        static void calculateMediana(int min, int max, int quantity)
        {
            float Nme;
            if(quantity % 2 == 0)
            {
                Nme = quantity / 2;
            } else { Nme = (quantity + 1) / 2; }
            float hme = max - min;
            float nme = quantity;
            float wynik = min + (Nme - 0) * (hme/nme);
            Console.WriteLine("Wynik mediany szeregu rodzielczego dla podanych danych to: " + wynik);
        }
    }
}
