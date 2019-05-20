using System;
using System.Linq;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').ToArray();
            int nodes = int.Parse(input[0]);
            int edges = int.Parse(input[1]);

            int[,] matrix = new int[nodes, nodes];

            for (int i = 0; i < edges; i++)
            {
                var edgeInfo = Console.ReadLine().Split(' ').ToArray();
                int node1 = int.Parse(edgeInfo[0]) -1;
                int node2 = int.Parse(edgeInfo[1]) -1;

                matrix[node1, node2] = 1;
                matrix[node2, node1] = 1;
            }

            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for (int row = 0; row < rowLength; row++)
            {
                for (int col = 0; col < colLength; col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}