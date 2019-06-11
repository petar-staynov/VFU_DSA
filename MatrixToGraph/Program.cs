using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixToGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of nodes");
            int nodes = int.Parse(Console.ReadLine());
            int[,] matrix = new int[nodes,nodes];

            Console.WriteLine("Enter Adjacency matrix in format \"0 0 1 0\"");
            List<string> results = new List<string>();
            for (int row = 0; row < nodes; row++)
            {
                int[] inputLine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                for (int col = 0; col < inputLine.Length; col++)
                {
                    int colValue = inputLine[col];
                    if (colValue == 1)
                    {
                        int node1 = row + 1;
                        int node2 = col + 1;
                        if (node1 < node2)
                        {
                            results.Add($"{node1} {node2}");
                        }
                    }
                }
            }

            foreach (string result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
