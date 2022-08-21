using UnityEngine;
using System;
public class Node
{
    public float gCost;                 // The movement cost value from the starting node to this node to the current node
    public float fCost;                 // The total estimated cost from the start to the target node
    public bool isObstacle;             // Flag to mark whether it is an obstacle
    public Node parent;                 // Parent node
    public Vector3 position;            // Node position

    public Node(Vector3 pos)
    {
        fCost = 0.0f;
        gCost = 0.0f;
        isObstacle = false;
        parent = null;
        position = pos;
    }
    public void MarkAsObstacle()
    {
        isObstacle = true;
    }

    /* Even if the Node class has multiple attributes, two nodes that represent the same position should be considered equal as far as 
       the search algorithm is concerned. The way to do that is to override the default Equals and GetHashCode methods */
    public override bool Equals(object obj)
    {
        return obj is Node node && position.Equals(node.position);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(position);
    }
}