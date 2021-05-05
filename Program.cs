using System;
using System.Linq;

namespace MaxFlowAlgorithm
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] ve = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

			int V = ve[0];
			int E = ve[1];
			FlowNetwork network = new FlowNetwork(V);
			for(int i = 0; i < E; i++){
				int[] tokens = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
				network.AddOrUpdateEdge(tokens[0], tokens[1], new NetworkEdge(0, tokens[2]));
			}
			int[] st = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
			network.S = st[0];
			network.T = st[1];


			IFindPath findPath = new BFS();

			int maxflow = 0;
			while (true)
			{
				int[] path = findPath.Find(network.Residual, network.S, network.T)?.ToArray();
				if (path == null)
				{
					break;
				}
				int bottleneck = int.MaxValue;
				for(int i = 1; i < path.Count(); i++)
				{
					var edge = network.GetEdge(path[i - 1], path[i]);
					if(bottleneck > edge.Remaining)
					{
						bottleneck = edge.Remaining;
					}
				}
				maxflow += bottleneck;
				for (int i = 1; i < path.Count(); i++)
				{
					var edge = network.GetEdge(path[i - 1], path[i]);
					network.AddOrUpdateEdge(path[i - 1], path[i], new NetworkEdge(edge.Flow + bottleneck, edge.Capacity));
				}
			}
			Console.WriteLine($"Maximum possible flow is {maxflow}");
		}
	}
}
