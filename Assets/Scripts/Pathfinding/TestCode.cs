using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestCode : MonoBehaviour
{
    private Vector3 startPos, endPos;

    public Node StartNode { get; set; }
    public Node GoalNode { get; set; }

    public List<Node> pathArray;


    private float elapsedTime = 0.0f;
    public float intervalTime = 1.0f; //Interval time between path finding


    private void Awake()
    {
        endPos = transform.position; 
    }

    // Use this for initialization
    void Start()
    {
        //AStar Calculated Path
        pathArray = new List<Node>();
    }

    // Update is called once per frame
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
        startPos = UnitActionSystem.Instance.GetSelectedUnit().transform.position;
        endPos = MouseWorld.GetPositionOnGround();

        //Assign StartNode and Goal Node
        var (startColumn, startRow) = AIGridManager.Instance.GetGridCoordinates(startPos);
        var (goalColumn, goalRow) = AIGridManager.Instance.GetGridCoordinates(endPos);
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