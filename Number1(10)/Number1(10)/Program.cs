using System;
using System.IO;

namespace Number1_10_
{
    class Program
    {
        static void Main(string[] args)
        {
            bool mark = true;
            while (mark)
            {
                Console.WriteLine("Выберите вид массива:\n1)Массив из 100000 элементов, сгенерированный случайным образом\n2)Отсортированный массив из 100000 элементов по возрастанию\n3)Отсортированный массив из 100000 элементов по убыванию\n4)Выход");
                string result1 = Console.ReadLine();
                Console.Clear();
                switch (result1)
                {
                    case "1":

                        int[] array = GivenArray();
                        Console.WriteLine("Выберите алгоритм сортировки:\n1)Пирамидальная сортировка\n2)Сортировка слиянием\n3)Быстрая сортировка\n4)Выход");
                        string result2 = Console.ReadLine();
                        Console.Clear();
                        switch (result2)
                        {
                            case "1":
                                TestingHeapSort(array, 0, 0);
                                CheckInputCorrect(array);
                                TransferForFile(array);
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "2":
                                TestingMergeSort(array, 0, 0);
                                CheckInputCorrect(array);
                                TransferForFile(array);
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "3":
                                TestingQuickSort(array, 0, 0);
                                CheckInputCorrect(array);
                                TransferForFile(array);
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "4":
                                mark = false;
                                break;
                        }
                        break;
                    case "2":
                        int[] Array = UpperSortedArray();
                        Console.WriteLine("Выберите метод(алгоритм) сортировки:\n1)Пирамидальная сортировка\n2)Сортировка слиянием\n3)Быстрая сортировка\n4)Выход");
                        string result3 = Console.ReadLine();
                        Console.Clear();
                        switch (result3)
                        {
                            case "1":
                                TestingHeapSort(Array, 0, 0);
                                CheckInputCorrect(Array);
                                TransferForFile(Array);
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "2":
                                TestingMergeSort(Array, 0, 0);
                               CheckInputCorrect(Array);
                                TransferForFile(Array);
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "3":
                                TestingQuickSort(Array, 0, 0);
                                CheckInputCorrect(Array);
                                TransferForFile(Array);
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "4":
                                mark = false;
                                break;
                        }
                        break;
                    case "3":
                        int[] massive = LowerSortedArray();
                        Console.WriteLine("Выберите алгоритм сортировки:\n1)Пирамидальная сортировка\n2)Сортировка слиянием\n3)Быстрая сортировка\n4)Выход");
                        string secondanswer3 = Console.ReadLine();
                        Console.Clear();
                        switch (secondanswer3)
                        {
                            case "1":
                                TestingHeapSort(massive, 0, 0);
                                CheckInputCorrect(massive);
                                TransferForFile(massive);
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "2":
                                TestingMergeSort(massive, 0, 0);
                                CheckInputCorrect(massive);
                                TransferForFile(massive);
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "3":
                                TestingQuickSort(massive, 0, 0);
                                CheckInputCorrect(massive);
                                TransferForFile(massive);
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "4":
                                mark = false;
                                break;
                        }
                        break;
                    case "4":
                        mark = false;
                        break;
                }
            }
        }
        static int[] LowerSortedArray()
        {
            Random random = new Random();
            int[] massive = new int[100000];
            for (int i = 0; i < massive.Length; i++)
            {
                massive[i] = random.Next(0, 1000);
            }
            int left = 0;
            int right = massive.Length - 1;
            int N = right - left + 1;
            for (int i = massive.Length - 1; i >= 0; i--)
            {
                HeapifyUpper(massive, i, N);
            }
            while (N > 0)
            {
                Swap(ref massive[left], ref massive[N - 1]);
                Heapify(massive, left, --N, ref left, ref right);
            }
            return massive;
        }
        static int[] GivenArray()
        {
            Random random = new Random();
            int[] massive = new int[100000];
            for (int i = 0; i < massive.Length; i++)
            {
                massive[i] = random.Next(0, 1000);
            }
            return massive;
        }
        static int[] UpperSortedArray()
        {
            Random random = new Random();
            int[] massive = new int[100000];
            for (int i = 0; i < massive.Length; i++)
            {
                massive[i] = random.Next(0, 1000);
            }
            int left = 0;
            int right = massive.Length - 1;
            int N = right - left + 1;
            for (int i = massive.Length - 1; i >= 0; i--)
            {
                HeapifyUpper(massive, i, N);
            }
            while (N > 0)
            {
                Swap(ref massive[left], ref massive[N - 1]);
                HeapifyUpper(massive, left, --N);
            }
            return massive;
        }
        static int Partition(int[] array, int left, int right, ref int counter, ref int pos)
        {
            int pivot = array[right];
            int i = left - 1, j = right;

            while (i < j)
            {
                while (array[++i] > pivot) ;
                while (array[--j] < pivot)
                {
                    counter++;
                    if (j == 0)
                    {
                        break;
                    }
                }
                counter++;
                if (i < j)
                {
                    pos++;
                    Swap(ref array[i], ref array[j]);
                }
                else
                {
                    break;
                }
            }
            pos++;
            Swap(ref array[i], ref array[right]);

            return i;
        }
        static void Merge(int[] array, int left, int midpos, int right, ref int counter, ref int pos)
        {
            int[] temp = new int[right - left + 1];
            int i = left, j = midpos + 1;
            int k = 0;
            for (k = 0; k < temp.Length; k++)
            {
                counter++;
                if (i > midpos)
                {
                    pos++;
                    temp[k] = array[j++];
                }
                else if (j > right)
                {
                    pos++;
                    temp[k] = array[i++];
                }
                else
                {
                    counter++;
                    pos++;
                    temp[k] = (array[i] > array[j]) ? array[i++] : array[j++];
                }
            }
            k = 0;
            i = left;
            while (k < temp.Length && i <= right)
            {
                counter++;
                array[i++] = temp[k++];
            }
        }
        static void MergeSort(int[] array, int left, int right, ref int counter, ref int pos)
        {
            if (right <= left)
            {
                return;
            }
            int mid = (left + right) / 2;
            MergeSort(array, left, mid, ref counter, ref pos);
            MergeSort(array, mid + 1, right, ref counter, ref pos);
            Merge(array, left, mid, right, ref counter, ref pos);
        }
        static void QuickSort(int[] array, int left, int right, ref int counter, ref int pos)
        {
            if (right <= left)
            {
                return;
            }
            int p = Partition(array, left, right, ref counter, ref pos);
            QuickSort(array, left, p - 1, ref counter, ref pos);
            QuickSort(array, p + 1, right, ref counter, ref pos);
        }
        static void HeapSort(int[] array, ref int counter, ref int pos)
        {
            int left = 0;
            int right = array.Length - 1;
            int N = right - left + 1;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                Heapify(array, i, N, ref counter, ref pos);
            }
            while (N > 0)
            {
                Swap(ref array[left], ref array[N - 1]);
                Heapify(array, left, --N, ref counter, ref pos);
            }
        }
        static void Heapify(int[] array, int i, int N, ref int counter, ref int pos)
        {
            while (2 * i + 1 < N)
            {
                int k = 2 * i + 1;
                counter++;
                if (2 * i + 2 < N && array[2 * i + 2] <= array[k])
                {
                    k = 2 * i + 2;
                }
                counter++;
                if (array[i] > array[k])
                {
                    pos++;
                    Swap(ref array[i], ref array[k]);
                    i = k;
                }
                else
                {
                    break;
                }
            }
        }
        static void HeapifyUpper(int[] array, int i, int N)
        {
            while (2 * i + 1 < N)
            {
                int k = 2 * i + 1;
                if (2 * i + 2 < N && array[2 * i + 2] >= array[k])
                {
                    k = 2 * i + 2;
                }
                if (array[i] > array[k])
                {
                    Swap(ref array[i], ref array[k]);
                    i = k;
                }
                else
                {
                    break;
                }
            }
        }

        static void TestingMergeSort(int[] array, int counter, int tranpos)
        {
            DateTime begin = DateTime.Now;
            MergeSort(array, 0, array.Length - 1, ref counter, ref tranpos);
            DateTime stop = DateTime.Now;
            TimeSpan testing = stop.Subtract(begin);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Продолжительность работы: {testing.Minutes}:{testing.Seconds}:{testing.Milliseconds}");
            Console.WriteLine("Количество сравнений: " + counter);
            Console.WriteLine("Количество перестановок: " + tranpos);
        }

        static void TestingQuickSort(int[] array, int counter, int tranpos)
        {
            DateTime begin = DateTime.Now;
            QuickSort(array, 0, array.Length - 1, ref counter, ref tranpos);
            DateTime stop = DateTime.Now;
            TimeSpan testing = stop.Subtract(begin);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Продолжительность работы: {testing.Minutes}:{testing.Seconds}:{testing.Milliseconds}");
            Console.WriteLine("Количество сравнений: " + counter);
            Console.WriteLine("Количество перестановок: " + tranpos);
        }
        static void TestingHeapSort(int[] array, int counter, int tranpos)
        {
            DateTime begin = DateTime.Now;
            HeapSort(array, ref counter, ref tranpos);
            DateTime stop = DateTime.Now;
            TimeSpan testing = stop.Subtract(begin);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Продолжительность работы: {testing.Minutes}:{testing.Seconds}:{testing.Milliseconds}");
            Console.WriteLine("Количество сравнений: " + counter);
            Console.WriteLine("Количество перестановок: " + tranpos);
        }

        static void CheckInputCorrect(int[] array)
        {
            bool mark = true;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] < array[i + 1])
                {
                    mark = false;
                    break;
                }
            }
            if (mark)
            {
                Console.WriteLine("Массив отсортирован верно");
            }
            else
            {
                Console.WriteLine("Массив отсортирован неверно");
            }
        }
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        static void TransferForFile(int[] array)
        {
            FileStream file = new FileStream(@"C:\Users\USER\source\repos\Number1(10)\sorted.dat", FileMode.OpenOrCreate);
            BinaryWriter write = new BinaryWriter(file);
            for (int i = 0; i < array.Length; i++)
            {
                write.Write(array[i]);
            }
            write.Close();
        }
    }
}
