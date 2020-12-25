using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace ShortestPathAlgorithm
{
    public class Edge
    {
        public readonly int From;
        public readonly int To;
        public readonly int Cost;

        public Edge(int h1, int h2, int c)
        {
            From = h1;
            To = h2;
            Cost = c;
        }

        public override bool Equals(object obj)
        {
            var e = obj as Edge;
            return From == e.From && To == e.To && Cost == e.Cost;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return (From+To)*Cost;
            }
        }
    }

    class Graph 
    {
        public List<Edge> Edges = new List<Edge>(); // лист ребер
        public Dictionary<int, Dictionary<int, int>> Nodes = new Dictionary<int, Dictionary<int, int>>(); // Лист вершин
        public Graph()
        {
        }
        public Graph(List<int> input)
        {
            if (((input.Count / 3d) - (double)(int)(input.Count / 3) != 0)) //Делимость на 3
                Console.WriteLine("Wrong Input");
            else
            {
                for (int i = 0; i < input.Count; i += 3)
                {
                    AddEdge(input[i], input[i + 1], input[i + 2]);
                }
            }
            
        }
        public Graph(List<Edge> edges)
        {
            foreach( var e in edges)
            {
                AddEdge(e.From, e.To, e.Cost);
            }
        }
        public void AddEdge(int h1, int h2, int c) // добавляем новое ребро
        {
            AddNode(h1, h2, c);

            Edges.Add(new Edge(h1, h2, c));
            Edges.Sort((x, y) => {
                if (x.Cost == y.Cost) return 0;
                else if (x.Cost <= y.Cost) return -1;
                else return 1;
            });
        }

        private void AddNode(int h1, int h2, int c) // Добавляем новую связь или вершину
        {
            if (!Nodes.ContainsKey(h1))
                Nodes.Add(h1, new Dictionary<int, int> { { h2, c } });
            else if(!Nodes[h1].ContainsKey(h2))
                Nodes[h1].Add(h2, c);
            
            if (!Nodes.ContainsKey(h2))
                Nodes.Add(h2, new Dictionary<int, int> { { h1, c } });
            else if(!Nodes[h2].ContainsKey(h1))
                Nodes[h2].Add(h1, c);
        }

        public void DeleteEdge(int h1, int h2)
        {
            if (!Nodes.ContainsKey(h1) || !Nodes.ContainsKey(h1))
                Console.WriteLine("there is no such nodes");
            else
            {
                Nodes[h1].Remove(h2);
                Nodes[h2].Remove(h1);

                for (int i = Edges.Count-1; i > 0; i--)
                {
                    if ((Edges[i].From == h1 && Edges[i].To == h2) || (Edges[i].To == h1 && Edges[i].From == h2))
                        Edges.RemoveAt(i);
                    return;
                }
            }
        }

        public void DeleteVertex(int h1)
        {
            foreach (var e in Edges)
            {
                if (e.From == h1 || e.To == h1)
                    Edges.Remove(e);
            }
        }

        public void PrintEdgeList()
        {
            foreach(var e in Edges)
            {
                Console.WriteLine("Цена: |"+ e.Cost + "| " + e.From + " - " + e.To);
            }
        }

        public IEnumerable<Edge> GetMinEdge (int node)
        {
            var edges = Nodes[node].OrderBy(x => x.Value);
            foreach (var e in edges)
            {
                yield return new Edge(node, e.Key, e.Value);
            }
        }

        public List<Edge> GetEdges(int node)
        {
            return Nodes[node].Select(x => new Edge(node, x.Key, x.Value)).ToList();
        }

    }
}
