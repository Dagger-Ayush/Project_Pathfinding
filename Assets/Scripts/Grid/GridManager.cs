using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] GameObject ground;
    [SerializeField] GameObject tile;
    [SerializeField] int rows = 20; // 1 cube equals 2 units (according to asset)
    [SerializeField] int columns = 20; 

    // Array for grid isn't used because array starts from the index 0 and the index where the tile( ground gameobject) is to be placed is 1,1 

    void Start()
    {
        GenerateGrid();
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
    
}
