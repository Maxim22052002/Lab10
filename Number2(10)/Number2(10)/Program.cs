using System;

namespace Number2_10_
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] banknotes = new int[100];
            banknotes = BanknodesRandom(banknotes);
            for (int i = 0; i < banknotes.Length; i++)
            {
                Console.Write(banknotes[i] + " ");
            }
                
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Отсортированный массив методом-подсчета: ");

            CountingSort(banknotes);
            for (int i = 0; i < banknotes.Length; i++)
            {
                Console.Write(banknotes[i] + " ");
            }
                
        }
        public static int[] BanknodesRandom(int[] banknotes)
        {
            Random random = new Random();
            for (int i = 0; i < banknotes.Length; i++)
            {
                banknotes[i] = random.Next(7); 
                switch (banknotes[i])
                {
                    case 1:
                        banknotes[i] = 1;
                        break;
                    case 2:
                        banknotes[i] = 2;
                        break;
                    case 3:
                        banknotes[i] = 5;
                        break;
                    case 4:
                        banknotes[i] = 10;
                        break;
                    case 5:
                        banknotes[i] = 20;
                        break;
                    case 6:
                        banknotes[i] = 50;
                        break;
                    case 0:
                        banknotes[i] = 100;
                        break;
                }
            }
            return banknotes;
        }
        public static void CountingSort(int[] array)
        {
            int left = 0, right = array.Length - 1;
            int min = 0, max = 0;
            for (int i = left; i <= right; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
                    
                else if (array[i] > max)
                {
                    max = array[i];
                }
                    
            }
            int bn = max - min + 1;
            int[] buckets = new int[bn];
            for (int i = left; i <= right; i++)
            {
                buckets[array[i] - min]++;
            }
                
            int index = 0;
            for (int i = min; i <= max; i++)
            {
                for (int j = 0; j < buckets[i - min]; j++)
                {
                    array[index++] = i;
                }
                    
            }
                
        }
    }
}
