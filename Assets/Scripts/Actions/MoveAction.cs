using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : MonoBehaviour
{
    [SerializeField] private Animator unitAnimator;

    private Unit unit;

    readonly private float moveSpeed = 3.0f;
    readonly private float rotationSpeed = 7.5f;
    readonly private float stopDis = 0.1f;

    private Vector3 targetPos;
    private List<Vector3> pathfindingList;
    private int currentPosIndex;

    void Awake()
    {
        targetPos = transform.position;
        unit = GetComponent<Unit>();
        pathfindingList = new List<Vector3>();
        currentPosIndex = 0;
    }

    private void Update()
    {
        if (unit == UnitActionSystem.Instance.GetSelectedUnit())
            targetPos = SetTargetPos(pathfindingList);             // If it's not getting input through 'UnitActionSystem' an empty list is feeded as an input, and hence unit dosen't move 
        else
            targetPos = transform.position;

        // Unit Movement
        if (Vector3.Distance(transform.position, targetPos) > stopDis)
        {
            Pathfinding.Instance.isMoving = true;
            Vector3 moveDirection = (targetPos - transform.position).normalized;

            transform.forward = rotationSpeed * Time.deltaTime * moveDirection;
            transform.position += moveSpeed * Time.deltaTime * moveDirection;

            unitAnimator.SetBool("IsRunning", true);
        }
        else
        {
            currentPosIndex++;

            if (transform.position == targetPos)
                unitAnimator.SetBool("IsRunning", false);
        }
    }

    // Fumction to get pathfinding positions one by one
    public Vector3 SetTargetPos(List<Vector3> posList)
    {
        // Getting Pathfinding Route from pathfinding script
        pathfindingList = posList;

        if (currentPosIndex < pathfindingList.Count)
            return pathfindingList[currentPosIndex];

        if (currentPosIndex >= pathfindingList.Count)
        {
            Pathfinding.Instance.isMoving = false;
            currentPosIndex = 0;
            pathfindingList.Clear();
        }
        return transform.position;
    }

}
