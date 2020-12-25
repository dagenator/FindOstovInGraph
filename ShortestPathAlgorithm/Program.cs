using System;
using System.Collections.Generic;

namespace ShortestPathAlgorithm
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Graph graph1 = new Graph(new List<int> {
            1,2,3, 2,3,2,  1,3,1, 1,4,4, 4,3,2, 3,5,2
            });
            //FindOstov(graph1);

            Graph graph2 = new Graph(new List<int> {
            1,8,3,
            1,7,2,
            1,4,5,
            2,4,7,
            3,4,1,
            3,6,3,
            4,5,2,
            4,6,5,
            5,6,6,
            6,7,2,
            7,8,4
            });
            FindOstov(graph2);

        }
        
        private static void FindOstov(Graph g)
        {
            KraskalAlgorithm Krascal = new KraskalAlgorithm();
            PrimaAlgorithm prima = new PrimaAlgorithm();
            Console.WriteLine("Whole Graph");
            g.PrintEdgeList();
            Console.WriteLine();

            Console.WriteLine("_______ Krascal_Algorithm_________________________________");
            var g2 = Krascal.FindOstov(g);
            g2.PrintEdgeList();
            Console.WriteLine();

            Console.WriteLine("_______ Prima_Algorithm___________________________________");
            var g3 = prima.FindOstov(g, 1);
            g3.PrintEdgeList();

        }
    }
}
