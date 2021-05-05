using System;
using System.Collections.Generic;

namespace MaxFlowAlgorithm
{
	public class BFS : IFindPath
	{

		public IEnumerable<int> Find(IGraph graph, int source, int target)
		{
			Queue<int[]> q = new Queue<int[]>();
			bool[] visited = new bool[graph.V];
			q.Enqueue(new int[] { source });
			while(q.Count > 0){
				int[] path = q.Dequeue();
				int v = path[path.Length - 1];
				if (v == target)
				{
					return path;
				}
				foreach(int vertex in graph.GetAdjacent(v))
				{
					if (!visited[vertex])
					{
						int[] newPath = new int[path.Length + 1];
						Array.Copy(path, newPath, path.Length);
						newPath[newPath.Length - 1] = vertex;
						visited[vertex] = true;
						q.Enqueue(newPath);
					}
				}
			}
			return null;
		}
	}
}
