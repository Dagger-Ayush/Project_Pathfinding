using UnityEngine;
using System.Collections.Generic;
public class AStar
{
 
    private float HeuristicEstimateCost(Node curNode, Node goalNode) // hCost
    {
        return (curNode.position - goalNode.position).magnitude;
    }

    public List<Node> FindPath(Node start, Node goal)
    {
        // Start Finding the path
        // Get the first node from our openList. Remember, openList is always sorted in increasing order. Therefore, the first node is always the node with the
        // lowest F value.

        NodePriorityQueue openList = new();
        openList.Enqueue(start);
        start.gCost = 0.0f;
        start.fCost = HeuristicEstimateCost(start, goal);
        HashSet<Node> closedList = new();
        Node node = null;


        // Check whether the current node is already at the target node. If so, exit the while loop and build the path array.
        while (openList.Length != 0)
        {
            node = openList.Dequeue();

            if (node.position == goal.position)
            {
                return CalculatePath(node);
            }

            var neighbours = AIGridManager.Instance.GetNeighbours(node);

            // Create an array list to store the neighboring nodes of the current node being processed.
            // Then, use the GetNeighbours method to retrieve the neighbors from the grid
            foreach (Node neighbourNode in neighbours)
            {
                // For every node in the array of neighbors, we check whether it's already in closedList.If not, we calculate the cost values,
                // update the node properties with the new cost values and the parent node data, and put it in openList.
                if (!closedList.Contains(neighbourNode))
                {
                    float totalCost = node.gCost + AIGridManager.Instance.StepCost;
                    float heuristicValue = HeuristicEstimateCost(neighbourNode, goal);
                    //Assign neighbour node properties
                    neighbourNode.gCost = totalCost;
                    neighbourNode.parent = node;
                    neighbourNode.fCost = totalCost + heuristicValue;

                    //Add the neighbour node to the queue
                    if (!closedList.Contains(neighbourNode))
                    {
                        openList.Enqueue(neighbourNode);
                    }
                }
            }
            // Push the current node to closedList and remove it from openList
            closedList.Add(node);
        }

        //If finished looping and cannot find the goal then return null
        if (node.position != goal.position)
        {
            Debug.LogError("Goal Not Found");
            return null;
        }

        //Calculate the path based on the final node
        return CalculatePath(node);

        // We call the CalculatePath method with the current node parameter
        static List<Node> CalculatePath(Node node)
        {
            List<Node> list = new();
            while (node != null)
            {
                list.Add(node);
                node = node.parent;
            }
            list.Reverse();
            return list;
        }

        /* The CalculatePath method traces through each node's parent node object and builds an array list. Since we want a path array from the start node 
           to the target node, we just call the Reverse method */
    }

}