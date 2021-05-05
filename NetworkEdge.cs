namespace MaxFlowAlgorithm
{
	public class NetworkEdge
    {
        public NetworkEdge(int flow, int capacity)
        {
            Flow = flow;
            Capacity = capacity;
        }

        public int Flow { get; }
        public int Capacity { get; }
        public int Remaining => Capacity - Flow;
    }
}
