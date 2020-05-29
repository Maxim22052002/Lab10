using System;
using System.Collections;
using System.Collections.Generic;

namespace Number3_10_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[,] Initmatrix =
                {
                    {0,1,1,0,0,0,0,0}, //1
                    {1,0,0,0,0,1,1,0}, //2
                    {1,0,0,1,0,1,0,1}, //3
                    {0,0,1,0,1,0,0,0}, //4
                    {0,0,0,1,0,1,0,0}, //5
                    {0,1,1,0,1,0,0,0}, //6
                    {0,1,0,0,0,0,0,1}, //7
                    {0,0,1,0,0,0,1,0}  //8
                  // 1 2 3 4 5 6 7 8
};

            GraphMatrix Graph = new GraphMatrix(Initmatrix, 8);

            int X = 0; int Y = 0;


            Console.WriteLine("Введите вершину X:");

            CheckInputCorrect(ref X);

            Console.WriteLine("Введите вершину Y:");

            CheckInputCorrect(ref Y);

            Console.WriteLine("Граф, представленный в виде матрицы инцидентности: ");


            Console.WriteLine("DFS: ");
            Stack<int> DFSMatrix = Graph.DFS(X - 1, Y - 1);
            ShowForStack(DFSMatrix);
            Console.WriteLine();

            Console.WriteLine("BFS: ");
            Stack<int> BFSMatrix = Graph.BFS(X - 1, Y - 1);
            ShowForStack(BFSMatrix);
            Console.WriteLine();

            

            Console.WriteLine("Граф, представленный в виде связного списка: ");
            Dictionary<int, List<int>> graph1 = new Dictionary<int, List<int>>
            {
                [1] = new List<int> { 2, 3 },
                [2] = new List<int> { 1, 6, 7 },
                [3] = new List<int> { 1, 4, 6, 8 },
                [4] = new List<int> { 3, 5 },
                [5] = new List<int> { 4, 6 },
                [6] = new List<int> { 2, 3, 5 },
                [7] = new List<int> { 2, 8 },
                [8] = new List<int> { 3, 7 },
            };
            

            GraphLinkedList GraphLinkedList = new GraphLinkedList(graph1, 8);
            Console.WriteLine("DFS: ");
           
            Stack<int> DFSLinkedList = GraphLinkedList.DFS(X - 1, Y - 1);
            ShowForStack(DFSLinkedList);
            Console.WriteLine();
            Console.WriteLine("BFS:");
           
            Stack<int> BFSLinkedList = GraphLinkedList.BFS(X - 1, Y - 1);
            ShowForStack(BFSLinkedList);

            Console.ReadKey();
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
                    {
                        Console.WriteLine("Введите верное значение");
                    }
                        
                }
                catch
                {
                    Console.WriteLine("Введите верное значение");
                }
            }
        }

        static void ShowForStack(Stack<int> stack)
        {
            int counter = 0;
            foreach (int i in stack)
            {
                if(counter == 0)
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
