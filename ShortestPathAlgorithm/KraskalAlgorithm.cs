using System;
using System.Collections.Generic;
using System.Text;

namespace ShortestPathAlgorithm
{
    class KraskalAlgorithm
    {
        public Graph FindOstov( Graph graph)
        {
            var sum = 0;
            var ShortGraph = new Graph();
            foreach (var e in graph.Edges)
            {
                ShortGraph.AddEdge(e.From, e.To, e.Cost);

                if (ShortGraph.Nodes.Count > 2 && HasCycle(ShortGraph))
                    ShortGraph.DeleteEdge(e.From, e.To);
                else
                    sum += e.Cost;

                if (ShortGraph.Nodes.Count == graph.Nodes.Count)
                    break;

            }
            Console.WriteLine("Cost Of new Graph: " + sum);
            return ShortGraph;
        }

        public static bool HasCycle(Graph graph)
        {
            var visited = new List<int>();  // Серые вершины
            var finished = new List<int>(); // Черные вершины
            var stack = new Stack<int>();
            visited.Add(1);
            stack.Push(1);
            while (stack.Count != 0)
            {
                var node = stack.Pop();
                foreach (var nextNode in graph.Nodes[node].Keys)
                {
                    if (finished.Contains(nextNode)) continue;
                    if (visited.Contains(nextNode)) return true;
                    visited.Add(nextNode);
                    stack.Push(nextNode);
                }
                finished.Add(node); // красим в черный, когда рассмотрели все пути из node
            }
            return false;
        }


    }
}
