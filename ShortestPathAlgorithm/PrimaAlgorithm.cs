using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShortestPathAlgorithm
{
    class PrimaAlgorithm
    {
        public Graph FindOstov(Graph graph, int begin) // begin - начальная нода
        {
            var sum = 0;
            var usedNodes = new List<int> { begin};
            var possibleEdges = graph.GetEdges(begin).ToList();
            var newGraph = new List<Edge>();
            while (usedNodes.Count != graph.Nodes.Count)
            {
                var minEdge = possibleEdges.OrderBy(x => x.Cost).FirstOrDefault();
                while (usedNodes.Contains(minEdge.From) && usedNodes.Contains(minEdge.To))
                {
                    possibleEdges.Remove(minEdge);
                    minEdge = possibleEdges.OrderBy(x => x.Cost).FirstOrDefault();
                }
                newGraph.Add(minEdge);
                sum += minEdge.Cost;
                if (!usedNodes.Contains(minEdge.To))
                {
                    usedNodes.Add(minEdge.To);
                    possibleEdges = possibleEdges.Concat(graph.GetEdges(minEdge.To).ToList()).ToList();
                }
                possibleEdges.Remove(minEdge);
                possibleEdges.Remove(new Edge(minEdge.To, minEdge.From, minEdge.Cost));
            }
            Console.WriteLine("Cost Of new Graph: " + sum);
            return new Graph(newGraph);
        }
    }
}
