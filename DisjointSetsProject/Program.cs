using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisjointSetsProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Sets
            DisjointSet ds = new DisjointSet();     
            ds.MakeSet(1);
            ds.MakeSet(2);
            ds.MakeSet(3);
            ds.MakeSet(4);
            ds.MakeSet(5);
            ds.MakeSet(6);
            ds.MakeSet(7);
            
            // Join the Sets
            ds.Union(1, 2);
            ds.Union(2, 3);
            ds.Union(4, 5);
            ds.Union(6, 7);
            ds.Union(5, 6);
            ds.Union(3, 7);

            // Print the Set parents and perform path algorithm
            Console.WriteLine(ds.FindSet(1));
            Console.WriteLine(ds.FindSet(2));
            Console.WriteLine(ds.FindSet(3));
            Console.WriteLine(ds.FindSet(4));
            Console.WriteLine(ds.FindSet(5));
            Console.WriteLine(ds.FindSet(6));
            Console.WriteLine(ds.FindSet(7));

            Console.ReadLine();

        }
    }

    // Disjoint Set Class
    public class DisjointSet
    {
        private Dictionary<long, Node> map = new Dictionary<long, Node>();

        // Node containing data, rank, and patern
        public class Node
        {
            public long data;
            public Node parent;
            public int rank;
        }
        
        // Create a set with only one element.
        public void MakeSet(long theData)
        {
            Node node = new Node();
            node.data = theData;
            node.parent = node;
            node.rank = 0;
            map[theData] = node;
        }

        // Finds the root of this set
        public long FindSet(long theData)
        {
            return FindSet(map[theData]).data;
        }

        // Find the root recursively
        // - Does path compression also
        public Node FindSet(Node node)
        {
            Node parent = node.parent;
            if (parent == node)
                return parent;
            node.parent = FindSet(node.parent);
            return node.parent;
        }

        // Joins the two sets into one
        public void Union(long data1, long data2)
        {
            Node node1 = map[data1];
            Node node2 = map[data2];

            Node parent1 = FindSet(node1);
            Node parent2 = FindSet(node2);

            // if they are part of the same set do nothing
            if (parent1.data == parent2.data)
            {
                return;
            }

            // else - the parent becomes the node with the highest rank
            if (parent1.rank >= parent2.rank)
            {
                // increment rank only if both sets have the same rank
                parent1.rank = (parent1.rank == parent2.rank) ?
                    parent1.rank + 1 : parent1.rank;
                parent2.parent = parent1;
            } else
            {
                parent1.parent = parent2;
            }
        }
    }

}
