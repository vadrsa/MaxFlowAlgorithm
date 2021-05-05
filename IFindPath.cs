using System.Collections.Generic;

namespace MaxFlowAlgorithm
{
	public interface IFindPath
	{
		IEnumerable<int> Find(IGraph graph, int source, int target);
	}
}
