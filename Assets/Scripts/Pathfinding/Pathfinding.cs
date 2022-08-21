using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathfinding : MonoBehaviour
{
    public static Pathfinding Instance { get; set; }

    [HideInInspector] public Vector3 startPos, endPos;

    public Node StartNode { get; set; }
    public Node GoalNode { get; set; }

    public List<Node> pathArray;
    public List<Vector3> posList;
    [HideInInspector] public bool isMoving = false;

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {
        // AStar Calculated Path
        pathArray = new List<Node>();

        // Path in Vector3 
        posList = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        FindPathForPlayer();

        FindPathForEnemy();
    }

    // // Find Path for enemy if its enemy's turn
    private void FindPathForPlayer()
    {
        if (Input.GetMouseButtonDown(0) && !isMoving && TurnManager.Instance.IsPlayerTurn())
        {
            Vector3 start = UnitActionSystem.Instance.GetSelectedUnit().transform.position;
            Vector3 end = MouseWorld.GetPositionOnGround(); ;

            FindPath(start, end);
            SimplifyPath();
        }
    }

    // Find Path for enemy if its player's turn
    private void FindPathForEnemy()
    {
        if (!Pathfinding.Instance.isMoving && !TurnManager.Instance.IsPlayerTurn())
        {
            Vector3 start = EnemyAI.Instance.SetStartPosForEnemy();
            Vector3 end = EnemyAI.Instance.GetDestinationForEnemy();

            Pathfinding.Instance.FindPath(start, end);
            Pathfinding.Instance.SimplifyPath();
        }
    }

    // Function to Find A* Path
    public void FindPath(Vector3 begin, Vector3 cease)
    {
        startPos = begin;
        endPos = cease;

        // Assigning StartNode and Goal Node
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

    // Converting Node position to grid position 
    private void SimplifyPath()
    {
        if (pathArray == null)
            return;

        if (pathArray.Count > 0)
        {
            int index = 0;
            foreach (Node node in pathArray)
            {
                if (index < pathArray.Count)
                {
                    posList.Add(pathArray[index].position);
                    index++;
                }
            };
        }
    }

    public List<Vector3> GetPosList()
    {
        return posList;
    }

}