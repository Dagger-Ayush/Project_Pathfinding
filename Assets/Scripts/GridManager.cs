using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridManager : MonoBehaviour
{
    [SerializeField] GameObject ground;
    [SerializeField] GameObject tile;
    [SerializeField] int rows = 20; // 1 cube equals 2 units (according to asset)
    [SerializeField] int columns = 20; 
    public TextMeshProUGUI indexText;

    // Array for grid isn't used because array starts from the index 0 and the index where the tile( ground gameobject) is to be placed is 1,1 

    void Start()
    {
        GenerateGrid();
    }

    private void Update()
    {
        UpdateSelection(); 
    }

    private void GenerateGrid()
    {
        for (int x = 1; x < rows; x+=2)
        {
            for (int z = 1; z < columns; z+=2)
            {
                // Creating clones of cube and tile using 'Instantiate' method
                GameObject newCube = Instantiate(ground, transform);
                GameObject newTile = Instantiate(tile, transform);

                // Adding Script to each instantiated cube
                newCube.AddComponent<CubeInfo>();

                // Layer denotes the height, can be used later to stack tile(ground gamobject) over the ground floor
                float cubeFloor = 0.5f,tileFloor = 1.6f;
               
                // setting position for each new cube and tile
                newCube.transform.position = new Vector3(x, cubeFloor, z);
                newTile.transform.position = new Vector3(x, tileFloor, z);

                // Naming each new cube with it's respective position
                newCube.name = (x/2 + " , " + z/2);
            }
        }
    }

    void UpdateSelection()
    {
        // checking if the camera that is raycasting is the main one
        if (!Camera.main) 
            return;

        // Raycasting to show index while hovering
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 50.0f, LayerMask.GetMask("Base")))
        {
            // For representing the index from 1,1 to 10,10 +1 is added, for ex. 0 + 1 = (1,1)
            int indexX = (Mathf.FloorToInt(hit.point.x) / 2) + 1;
            int indexZ = (Mathf.FloorToInt(hit.point.z) / 2) + 1;

            // Printing the index through UI
            indexText.text = "Index : " + indexX + " , " + indexZ;
        }
    }
}
