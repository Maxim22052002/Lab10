using System;
using System.Collections.Generic;

namespace Number4_10_
{
    class Program
    {
		public static void Main(string[] args)
		{
			int[,] transNetwork = {
				{-1,20,90,-1,-1,-1,-1,-1}, //1
				{30,-1,-1,-1,-1,150,80,-1}, //2 
				{70,-1,-1,45,-1,50,-1,150}, //3 
				{-1,-1,70,-1,120,-1,-1,-1}, //4
				{-1,-1,-1,150,-1,30,-1,-1}, //5
				{-1,160,70,-1,50,-1,-1,-1}, //6
				{-1,60,-1,-1,-1,-1,-1,150}, //7
				{-1,-1,100,-1,-1,-1,100,-1}  //8
				//1  2  3   4  5  6  7   8
			};
			GraphDistance Graph = new GraphDistance(transNetwork, 8);
			int i = 0;
			Console.WriteLine("Введите номер города от 1-8: ");
			CheckInputCorrect(ref i);
			Dictionary<string,int> Distance = new Dictionary<string, int>();
			Console.WriteLine("Путь до городов: ");
			for (int j = 0; j < 8; j++)
			{
				if (!Distance.ContainsKey(i + " " + j + 1))
				{
					if (i != j + 1)
					{
						Stack<int> stackUsedBFS = Graph.BFS(i - 1, j);
						Path(stackUsedBFS);
						Console.WriteLine();
						Add(stackUsedBFS, transNetwork, ref Distance, i); 
					}

				}

			}
			foreach (KeyValuePair<string, int> keyValuePair in Distance)
			{
				if (keyValuePair.Value <= 200)
				{
					Console.WriteLine("Расстояние от "+keyValuePair.Key + " = " + keyValuePair.Value);
				}
					
			}
			
		}

		public static void Add(Stack<int> stack, int[,] a, ref Dictionary<string, int> dictionary, int beginPos)
		{
			int previous = -1;

			int sum = 0;
			foreach (int i in stack)
			{
				if (previous == -1)
				{
					previous = i;
				}
					
				else
				{
					sum += a[previous, i];
					previous = i;
					dictionary[beginPos +  " до " + (i + 1)] = sum;
				}
			}
		}

		public static void CheckInputCorrect(ref int i)
		{
			bool mark = false;
			while (!mark)
			{
				try
				{
					i = Convert.ToInt32(Console.ReadLine());
					if (i > 0 && i <= 8)
					{
						mark = true;
					}
						
					else
						Console.WriteLine("Введите верное значение.");
				}
				catch
				{
					Console.WriteLine("Введите верное значение.");
				}
			}
		}

		static void Path(Stack<int> stack)
		{
			int counter = 0;
			foreach (int i in stack)
			{
				if (counter == 0)
				{
					Console.Write(Convert.ToString(i + 1)); 
				}
				else
				{
					Console.Write("->" + (i + 1)); 
				}	
				counter++;
			}
		}
	}
}
