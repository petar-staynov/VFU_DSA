﻿using System;
using System.Collections.Generic;

namespace GraphImplementation
{
    class Program
    {
        private static readonly Graph Graph = new Graph(new List<int>[]
        {
            new List<int>() {3, 6}, // successors of vertice 0
            new List<int>() {2, 3, 4, 5, 6}, // successors of vertice 1
            new List<int>() {1, 4, 5}, // successors of vertice 2
            new List<int>() {0, 1, 5}, // successors of vertice 3
            new List<int>() {1, 2, 6}, // successors of vertice 4
            new List<int>() {1, 2, 3}, // successors of vertice 5
            new List<int>() {0, 1, 4} // successors of vertice 6
        });

        static void TraverseDFS(int node)
        {
            bool[] visited = new bool[Graph.Size];
            Stack<int> stack = new Stack<int>();

            stack.Push(node);
            visited[node] = true;

            while (stack.Count > 0)
            {
                int currentNode = stack.Pop();
                Console.WriteLine($"{currentNode} ");

                IList<int> childNodes = Graph.GetChildren(currentNode);
                foreach (int childNode in childNodes)
                {
                    if (!visited[childNode])
                    {
                        stack.Push(childNode);
                        visited[childNode] = true;
                    }
                }
            }
        }

        static void TraverseDFSRecursive(int node, bool[] visited)
        {
            //If node isn't visited traverse its children
            if (!visited[node])
            {
                Console.Write($"{node} ");
                visited[node] = true;

                IList<int> childrenNodes = Graph.GetChildren(node);
                foreach (int childNode in childrenNodes)
                {
                    TraverseDFSRecursive(childNode, visited);
                }
            }
        }

        static void TraverseBFS(int node)
        {
            bool[] visited = new bool[Graph.Size];
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(node);
            visited[node] = true;

            while (queue.Count > 0)
            {
                int currentNode = queue.Dequeue();
                Console.WriteLine($"{currentNode} ");
                IList<int> childrenNodes = Graph.GetChildren(currentNode);

                foreach (int childNode in childrenNodes)
                {
                    if (!visited[childNode])
                    {
                        queue.Enqueue(childNode);
                        visited[childNode] = true;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Breadth-First Search (BFS) traversal: ");
            TraverseBFS(0);
            Console.WriteLine();

            Console.Write("Depth-First Search (DFS) traversal (with stack): ");
            TraverseDFS(0);
            Console.WriteLine();

            Console.Write("Depth-First Search (DFS) traversal (recursive): ");
            bool[] visited = new bool[Graph.Size];
            TraverseDFSRecursive(0, visited);
            Console.WriteLine();
        }
    }
}