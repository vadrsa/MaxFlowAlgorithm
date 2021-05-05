namespace MaxFlowAlgorithm
{
    public class FlowNetwork : Graph<NetworkEdge>
    {
        public FlowNetwork(int V) : base(V)
        {
            Residual = new Graph<NetworkEdge>(V);
        }

        public int S { get; set; }
        public int T { get; set; }

        public override bool AddOrUpdateEdge(int u, int v, NetworkEdge edge)
        {
            bool added = base.AddOrUpdateEdge(u, v, edge);

            Residual.AddOrUpdateEdge(u, v, edge);

            if (edge.Capacity == edge.Flow)
            {
                Residual.RemoveEdge(u, v);
            }
            else if (edge.Flow > 0)
            {
                Residual.AddOrUpdateEdge(v, u, new NetworkEdge(-1 * edge.Flow, 0));
            }
            if (edge.Flow == 0)
            {
                Residual.RemoveEdge(v, u);
            }
            return added;
        }

        public Graph<NetworkEdge> Residual { get; }
    }
}