/* The AIGridManager class handles the 2D grid representation for the world map. We keep it as a singleton instance of the AIGridManager class, 
   as we only need one object to represent the map */

/* A singleton is a programming pattern that restricts the instantiation of a class to one object and, therefore, 
   it makes the instance easily accessible from any point of the application */

using UnityEngine;
using System.Collections.Generic;
public class AIGridManager : MonoBehaviour
{
    private static AIGridManager staticInstance = null;
    [SerializeField] private LayerMask obstacleLayer;
    public static AIGridManager Instance
    {
        get
        {
            if (staticInstance == null)
            {
                staticInstance = FindObjectOfType(typeof(AIGridManager)) as AIGridManager;
                if (staticInstance == null)
                    Debug.Log("Could not locate an AIGridManager object. \n You have to have exactly one AIGridManager in the scene.");
            }
            return staticInstance;
        }
    }

    // Ensure that the instance is destroyed when the game is stopped in the editor
    void OnApplicationQuit()
    {
        staticInstance = null;
    }

    // 'numOfRows' and 'numOfColumns' store the number of rows and columns of the grid
    public int numOfRows;
    public int numOfColumns;

    // represent size of each grid
    public float gridCellSize;

    // ObstacleEpsilon is the margin for the system we will use to detect obstacles
    public float obstacleEpsilon = 0.2f;

    // Two Boolean variables to enable or disable the debug visualization of the grid and obstacles
    public bool showGrid = true;
    public bool showObstacleBlocks = true;

    // To get the grid's origin in world coordinates (Origin) and the cost of moving from one tile to the other(StepCost)
    public Node[,] Nodes { get; set; }
    public Vector3 Origin
    {
        get { return transform.position; }
    }
    public float StepCost
    {
        get { return gridCellSize; }
    }

    void LateUpdate()
    {
        ComputeGrid();
    }

    void ComputeGrid()
    {
        //Initialise the Nodes
        Nodes = new Node[numOfColumns, numOfRows];
        for (int i = 0; i < numOfColumns; i++)
        {
            for (int j = 0; j < numOfRows; j++)
            {
                Vector3 cellPos = GetGridCellCenter(i, j);
                Node node = new(cellPos);

                // The OverlapSphere function is used to check whether the square is occupied by an obstacle
                // centering the sphere at the center of the grid's cell (cellPos) and define the sphere's radius as a bit less than the grid cell size
                var collisions = Physics.OverlapSphere(cellPos, gridCellSize / 2 - obstacleEpsilon, obstacleLayer);
                // If the OverlapSphere function returns anything, this means that we have an obstacle inside the cell and, therefore,
                // we define the entire cell as an obstacle.

                if (collisions.Length != 0)
                {
                    node.MarkAsObstacle();
                }
                Nodes[i, j] = node;
            }
        }
    }

    // GetGridCellCenter method returns the position of the grid cell in world coordinates from the cell coordinates
    public Vector3 GetGridCellCenter(int col, int row)
    {
        Vector3 cellPosition = GetGridCellPosition(col, row);
        cellPosition.x += gridCellSize / 2.0f;
        cellPosition.z += gridCellSize / 2.0f;
        return cellPosition;
    }
    public Vector3 GetGridCellPosition(int col, int row)
    {
        float xPosInGrid = col * gridCellSize;
        float zPosInGrid = row * gridCellSize;
        return Origin + new Vector3(xPosInGrid, 0.0f, zPosInGrid);
    }

    // Get the grid cell index in the Astar grids with the position given
    public (int, int) GetGridCoordinates(Vector3 pos)
    {
        if (!IsInBounds(pos))
        {
            return (-1, -1);
        }

        int col = (int)Mathf.Floor((pos.x - Origin.x) / gridCellSize);
        int row = (int)Mathf.Floor((pos.z - Origin.z) / gridCellSize);

        return (col, row);
    }
    // IsInBounds method checks whether a certain position in the game falls inside the grid
    public bool IsInBounds(Vector3 pos)
    {
        float width = numOfColumns * gridCellSize;
        float height = numOfRows * gridCellSize;
        return (pos.x >= Origin.x && pos.x <= Origin.x + width && pos.x <= Origin.z + height && pos.z >= Origin.z);
    }

    // IsTraversable method checks whether a grid coordinate is traversable (that is, it is not an obstacle)
    public bool IsTraversable(int col, int row)
    {
        return col >= 0 && row >= 0 && col < numOfColumns && row < numOfRows && !Nodes[col, row].isObstacle;
    }

    // GetNeighbours, which is used by the AStar class to retrieve the neighboring Nodes of a particular node.This is done by obtaining
    // the grid coordinate of the node and then checking whether the four neighbor's coordinates(up, down, left, and right) are traversable

    public List<Node> GetNeighbours(Node node)
    {
        List<Node> result = new();
        var (column, row) = GetGridCoordinates(node.position);


        if (IsTraversable(column - 1, row))
        {
            result.Add(Nodes[column - 1, row]);
        }
        if (IsTraversable(column + 1, row))
        {
            result.Add(Nodes[column + 1, row]);
        }
        if (IsTraversable(column, row - 1))
        {
            result.Add(Nodes[column, row - 1]);
        }
        if (IsTraversable(column, row + 1))
        {
            result.Add(Nodes[column, row + 1]);
        }
        return result;
    }

    // Debug aid methods used to visualize the grid and obstacle blocks
    void OnDrawGizmos()
    {
        if (showGrid)
        {
            DebugDrawGrid(Color.black);
        }

        //Grid Start Position
        Gizmos.DrawSphere(Origin, 0.5f);
        if (Nodes == null) return;

        //Draw Obstacle obstruction
        if (showObstacleBlocks)
        {
            Vector3 cellSize = new(gridCellSize, 1.0f, gridCellSize);
            Gizmos.color = Color.red;
            for (int i = 0; i < numOfColumns; i++)
            {
                for (int j = 0; j < numOfRows; j++)
                {
                    if (Nodes != null && Nodes[i, j].isObstacle)
                    {
                        Gizmos.DrawCube(GetGridCellCenter(i, j), cellSize);
                    }
                }
            }
        }
    }

    public void DebugDrawGrid(Color color)
    {
        float width = (numOfColumns * gridCellSize);
        float height = (numOfRows * gridCellSize);

        // Draw the horizontal grid lines
        for (int i = 0; i < numOfRows + 1; i++)
        {
            Vector3 startPos = Origin + i * gridCellSize * new Vector3(0.0f, 0.0f, 1.0f);
            Vector3 endPos = startPos + width * new Vector3(1.0f, 0.0f, 0.0f);
            Debug.DrawLine(startPos, endPos, color);
        }

        // Draw the vertial grid lines
        for (int i = 0; i < numOfColumns + 1; i++)
        {
            Vector3 startPos = Origin + i * gridCellSize * new Vector3(1.0f, 0.0f, 0.0f);
            Vector3 endPos = startPos + height * new Vector3(0.0f, 0.0f, 1.0f);
            Debug.DrawLine(startPos, endPos, color);
        }
    }
}

/* Gizmos can be used to draw visual debugging and setup aids inside the editor scene view.
OnDrawGizmos is called every frame by the engine. So, if the debug flags, showGrid
and showObstacleBlocks, are checked, we just draw the grid with lines and the
obstacle cube objects with cubes */