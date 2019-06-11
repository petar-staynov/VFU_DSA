using System;
using System.Collections.Generic;
using System.Linq;

namespace DSA_Exam_Problem2
{
    class Program
    {
        private readonly string exampleInput1 = @"
4
1 2 6
1 6
6
0

1 2 3
x
";

        private readonly string exampleInput2 = @"
1 2


4
3
5

x
";


        private static Graph _graph;
        private static bool[] visited;

        private static int currentComponent = 0;
        private static List<int> componentsLength;

        static void TraverseDFS(int v)
        {
            if (!visited[v])
            {
                Console.Write(v + " ");
                visited[v] = true;

                componentsLength[currentComponent]++;

                foreach (int child in _graph.GetChildren(v))
                {
                    TraverseDFS(child);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(
                "Input follows the format \"nodeNumber nodeNumber nodeNumber\". ex: \"1 2 6\".");

            List<List<int>> graphComponents = new List<List<int>>();

            Console.WriteLine();
            Console.WriteLine("Enter number of nodes/vertices");
            int numberOfNodes = int.Parse(Console.ReadLine());

            for (int currentNode = 0; currentNode <= numberOfNodes; currentNode++)
            {
                /*
                 *
                 *GRAPH COMPONENTS INPUT
                 *
                 */
                Console.Write($"Enter successors of vertice {currentNode} (press enter to create isolated vertice): ");
                string input = Console.ReadLine();

                List<int> graphComponent = new List<int>();

                int[] nodeInfo;
                try
                {
                    if (input.Length == 0)
                    {
                        Console.WriteLine("Isolated vertice added");
                        nodeInfo = new int[0];
                    }
                    else
                    {
                        nodeInfo = input.Split(' ').Select(int.Parse).ToArray();
                    }


                    foreach (int nodeNumber in nodeInfo)
                    {
                        if (nodeNumber > numberOfNodes)
                        {
                            Console.WriteLine("Node number cannot be greater than the total amount of nodes.");
                            currentNode--;
                            throw new Exception();
                        }

                        graphComponent.Add(nodeNumber);
                    }

                    graphComponents.Add(graphComponent);


                    Console.WriteLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input, try again!");
                }
            }

            //CREATE GRAPH
            _graph = new Graph(graphComponents);
            visited = new bool[_graph.Size];
            Console.WriteLine();

            //FIND CONNECTED GRAPH COMPONENTS USING RECURSIVE DFS
            Console.WriteLine("Connected graph components: ");
            componentsLength = new List<int>();
            for (int v = 0; v < _graph.Size; v++)
            {
                currentComponent = v;
                componentsLength.Add(0);

                if (!visited[v])
                {
                    TraverseDFS(v);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();

            //FIND LENGTHS OF CONNECTED COMPONENTS
            Dictionary<int, int> lengthOccurrences = new Dictionary<int, int>();
            for (int currComp = 0; currComp < componentsLength.Count; currComp++)
            {
                if (componentsLength[currComp] == 0) continue;

                int componentLength = componentsLength[currComp];
                //Console.WriteLine($"component{currComp} length = {componentLength}");

                if (!lengthOccurrences.ContainsKey(componentLength))
                {
                    lengthOccurrences[componentLength] = 1;
                }
                else
                {
                    lengthOccurrences[componentLength]++;
                }
            }

            Console.WriteLine();

            //PRINT NUMBER OF OCCURRENCES OF EACH LENGTH
            foreach (KeyValuePair<int, int> lengthOccurrence in lengthOccurrences)
            {
                Console.WriteLine(
                    $"There are {lengthOccurrence.Value} components with a length of {lengthOccurrence.Key}");
            }
        }
    }
}