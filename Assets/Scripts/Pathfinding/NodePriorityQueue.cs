/* A priority queue is an ordered data structure designed so that the first element (the head) of the list is always the smallest or largest element 
   (depending on the implementation).
   This data structure is the most efficient way to handle the nodes in the open list because, we need to quickly retrieve the node with the lowest fCost value. */

using System.Collections.Generic;
using System.Linq;

public class NodePriorityQueue
{
    private readonly List<Node> nodes = new();
    public int Length
    {
        get { return nodes.Count; }
    }
    public bool Contains(Node node)
    {
        return nodes.Contains(node);
    }
    public Node Dequeue()
    {
        if (nodes.Count > 0)
        {
            var result = nodes[0];
            nodes.RemoveAt(0);
            return result;
        }
        return null;
    }

    /* Enqueue method
        Before adding a new node, we need to check whether there is already a node with the same position but a lower fCost. If there is, we do nothing 
        (we already have a better node in the queue). If not, this means that the new node we are adding is better than the old one. Therefore, 
        we can remove the old one to ensure that we only have the best node possible for each position. */
    public void Enqueue(Node node)
    {
        if (nodes.Contains(node))
        {
            var oldNode = nodes.First(n => n.Equals(node));
            if (oldNode.fCost <= node.fCost)
            {
                return;
            }
            else
            {
                nodes.Remove(oldNode);
            }
        }
        nodes.Add(node);
        nodes.Sort((n1, n2) => n1.fCost < n2.fCost ? -1 : 1); // It relies on the Sort method to reorder the internal list of nodes after each Insertion
    }
}
