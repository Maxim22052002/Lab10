using System;
using System.Collections.Generic;
using System.Text;

namespace Number4_10_
{
    class GraphDistance
    {
		private int vertices = 0;

		private int[,] Graph = null;



		public GraphDistance(int[,] matrix, int numberOfvertices)
		{
			Graph = matrix;
			vertices = numberOfvertices;
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

		public Stack<int> BFS(int startPos, int endPos)
		{
			Queue<int> q = new Queue<int>();

			
			int[] vPath = new int[vertices];

			int[] checkedv = new int[vertices];
			q.Enqueue(startPos);
			checkedv[startPos] = 1;

			while (q.Count > 0)
			{
				int i = q.Dequeue();

				for (int j = 0; j < vertices; j++)
				{
					if (Graph[i, j] > -1 && checkedv[j] == 0)
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
