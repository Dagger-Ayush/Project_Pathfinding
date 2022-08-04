using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TestCode : MonoBehaviour
{
    private Transform startPos, endPos;
    public Node StartNode { get; set; }
    public Node GoalNode { get; set; }
    public List<Node> pathArray;

    GameObject objStartCube, objEndCube;
    private float elapsedTime = 0.0f;

    //Interval time between pathfinding
    public float intervalTime = 1.0f;

    void Start()
    {
        objStartCube = GameObject.FindGameObjectWithTag("Start");
        objEndCube = GameObject.FindGameObjectWithTag("End");
        pathArray = new List<Node>();
        FindPath();
    }
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= intervalTime)
        {
            elapsedTime = 0.0f;
            FindPath();
        }
    }
    void FindPath()
    {
        startPos = objStartCube.transform;
        endPos = objEndCube.transform;
        //Assign StartNode and Goal Node
        var (startColumn, startRow) = AIGridManager.Instance.GetGridCoordinates(startPos.position);
        var (goalColumn, goalRow) = AIGridManager.Instance.GetGridCoordinates(endPos.position);
        StartNode = new Node(AIGridManager.Instance.GetGridCellCenter(startColumn, startRow));
        GoalNode = new Node(AIGridManager.Instance.GetGridCellCenter(goalColumn, goalRow));
        pathArray = new AStar().FindPath(StartNode, GoalNode);
    }
    void OnDrawGizmos()
    {
        if (pathArray == null)
            return;
        if (pathArray.Count > 0)
        {
            int index = 1;
            foreach (Node node in pathArray)
            {
                if (index < pathArray.Count)
                {
                    Node nextNode = pathArray[index];
                    Debug.DrawLine(node.position, nextNode.position, Color.green);
                    index++;
                }
            };
        }
    }
}