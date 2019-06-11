using System;
using System.Collections.Generic;
using System.Linq;

namespace DSA_Exam_Problem2
{
    class Program
    {
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
                "Enter graph components in format \"nodeNumber nodeNumber nodeNumber\". ex: \"1 2 6\". Type \"x\" to exit");

            List<List<int>> graphComponents = new List<List<int>>();

            int currentNode = 0;
            while (true)
            {
                /*
                 *
                 *GRAPH COMPONENTS INPUT
                 *
                 */
                Console.Write($"Enter children of node{currentNode}: ");
                string input = Console.ReadLine();
                if (input == "x") break;


                List<int> graphComponent = new List<int>();

                int[] nodeInfo;
                try
                {
                    nodeInfo = input.Split(' ').Select(int.Parse).ToArray();
                }
                catch (Exception)
                {
                    //Create node with no connections on invalid input
                    Console.WriteLine("Disconnected node added");
                    nodeInfo = new int[0];
                }

                foreach (int nodeNumber in nodeInfo)
                {
                    graphComponent.Add(nodeNumber);
                }

                graphComponents.Add(graphComponent);
                currentNode++;
                Console.WriteLine();
            }

            //CREATE GRAPH
            var temp = new Graph(graphComponents);
            _graph = temp;
            visited = new bool[_graph.Size];
            Console.WriteLine();

            /*
             *
             *GRAPH TRAVERSAL
             *
             */
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
            for (int currComp = 0; currComp < componentsLength.Count; currComp++)
            {
                //if (componentsLength[currComp] == 0) continue;

                Console.WriteLine($"component{currComp} length = {componentsLength[currComp]}");
                currentComponent++;
            }

            Console.WriteLine();

            Console.WriteLine($"Number of components with same length:");
            var lengthsOccurences = new Dictionary<int, int>();
            foreach (var num in componentsLength)
            {
                if (!lengthsOccurences.ContainsKey(num))
                {
                    lengthsOccurences.Add(num, 0);
                }

                lengthsOccurences[num]++;
            }

            foreach (var kvp in lengthsOccurences)
            {
                //if (kvp.Key < 2) continue;

                Console.WriteLine($"{kvp.Value} components with a length of {kvp.Key}");
            }
        }
    }
}