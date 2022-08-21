using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseWorld : MonoBehaviour
{
    private static MouseWorld Instance;

    [SerializeField] TextMeshProUGUI indexText;
    [SerializeField] private LayerMask ground;  // ('ground') = Ground, Tile

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        transform.position = GetPositionOnGround();

        GetPositionIndex();
    }

    public void GetPositionIndex()
    {
        // Raycasting to show index while hovering
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 50.0f, Instance.ground))
        {
            // For representing the index from 1,1 to 10,10 +1 is added, for ex. 0 + 1 = (1,1)
            int indexX = (Mathf.FloorToInt(hit.point.x) / 2) + 1;
            int indexZ = (Mathf.FloorToInt(hit.point.z) / 2) + 1;

            // Printing the index through UI
            indexText.text = "Index : " + indexX + " , " + indexZ;
        }
    }

     // A Reference function to get position of mouse on the ground
    public static Vector3 GetPositionOnGround()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hitPos, 50.0f, Instance.ground)) // return true if mouse is on ground (not water) else returns selected unit positon
            return hitPos.point;
        else
            return UnitActionSystem.Instance.GetSelectedUnit().transform.position;
    }
}
