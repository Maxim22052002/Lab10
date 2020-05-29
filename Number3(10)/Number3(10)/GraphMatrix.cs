using System;
using System.Collections.Generic;
using System.Text;

namespace Number3_10_
{
    public class GraphMatrix
    {
        private int Vertices = 0;

        private int[,] Graph = null;

        public GraphMatrix(int[,] matrix, int numberOfvertices)
        {
            Graph = matrix;
            Vertices = numberOfvertices;
        }

        public Stack<int> backChain(int[] p, int startPos, int endPos)
        {
            int pos = endPos;

            Stack<int> pathStack = new Stack<int>();
            pathStack.Push(pos);

            while (pos != startPos)
            {
                pos = p[pos];
                pathStack.Push(pos);
            }

            return pathStack;
        }

        public Stack<int> DFS(int startPos, int endPos)
        {
            Stack<int> stack = new Stack<int>();
            int[] vPath = new int[Vertices];
            int[] checkedv = new int[Vertices];
            stack.Push(startPos);
            checkedv[startPos] = 1;
            while (stack.Count > 0)
            {
                int i = stack.Pop();

                for (int j = Vertices - 1; j >= 0; j--)
                {
                    if (Graph[i, j] > 0 && checkedv[j] == 0)
                    {
                        checkedv[j] = 1;
                        stack.Push(j);
                        vPath[j] = i;

                        if (j == endPos)
                        {
                            return backChain(vPath, startPos, endPos);
                        }
                    }
                }
            }

            return null;
        }

        public Stack<int> BFS(int startPos, int endPos)
        {
            Queue<int> q = new Queue<int>();
            int[] vPath = new int[Vertices];
            int[] checkedv = new int[Vertices];
            q.Enqueue(startPos);
            checkedv[startPos] = 1;
            while (q.Count > 0)
            {
                int i = q.Dequeue();

                for (int j = 0; j < Vertices; j++)
                {
                    if (Graph[i, j] > 0 && checkedv[j] == 0)
                    {
                        checkedv[j] = 1;
                        q.Enqueue(j);
                        vPath[j] = i;

                        if (j == endPos)
                        {
                            return backChain(vPath, startPos, endPos);
                        }
                    }
                }


            }
            return null;
        }
    }
}
