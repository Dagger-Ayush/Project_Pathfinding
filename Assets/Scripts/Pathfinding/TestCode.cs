using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TestCode : MonoBehaviour
{
    private Transform startPos, endPos;
    //private float speed = 10.0f;
    public Node StartNode { get; set; }
    public Node GoalNode { get; set; }
    public List<Node> pathArray;

    GameObject player, Enemy;
    private float elapsedTime = 0.0f;

    //Interval time between pathfinding
    public float intervalTime = 1.0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        pathArray = new List<Node>();
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
        startPos = player.transform;
        endPos = Enemy.transform;
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