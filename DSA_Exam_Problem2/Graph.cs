using System;
using System.Collections.Generic;
using System.Text;

namespace DSA_Exam_Problem2
{
    /*Unweighted graph structure*/
    public class Graph
    {
        //Child nodes of the graph - array of lists
        private List<List<int>> childNodes;

        //Constructs empty graph of <size>
        public Graph(int size)
        {
            this.childNodes = new List<List<int>>();
            for (int i = 0; i < size; i++)
            {
                //Assign a empty list of adjacents/neighbours to each vertex/node
                childNodes.Add(new List<int>());
            }
        }

        //Constructs a graph using a given list of child nodes
        public Graph(List<List<int>> childNodes)
        {
            this.childNodes = childNodes;
        }

        //Return size of graph - number of nodes/vertices
        public int Size
        {
            get { return this.childNodes.Count; }
        }

        //Add edge between two nodes
        public void AddEdge(int node1, int node2)
        {
            this.childNodes[node1].Add(node2);
        }

        //Removes edge between two nodes
        public void RemoveEdge(int node1, int node2)
        {
            this.childNodes[node1].Remove(node2);
        }

        //Check if there is a connection between node1 and node2
        public bool HasEdge(int node1, int node2)
        {
            return this.childNodes[node1].Contains(node2);
        }

        //Get the successors/children of a given node
        public IList<int> GetChildren(int node1)
        {
            return this.childNodes[node1];
        }
    }
}