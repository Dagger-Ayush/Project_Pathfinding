using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private Animator unitAnimator;

    readonly private float moveSpeed = 3.0f;
    readonly private float stopDis = 0.1f;

    private Vector3 targetPos;
    private List<Vector3> pathfindingList;
    private int currentPosIndex;

    void Awake()
    {
        targetPos = transform.position;
        pathfindingList = new List<Vector3>();
        currentPosIndex = 0;
    }

    private void Update()
    {
        pathfindingList = Pathfinding.Instance.GetPosList();
        targetPos = GetDestination();

        if (Vector3.Distance(transform.position, targetPos) > stopDis)
        {                 
            Vector3 moveDirection = (targetPos - transform.position).normalized;
            transform.position += moveSpeed * Time.deltaTime * moveDirection;
            transform.forward = moveDirection;

            unitAnimator.SetBool("IsRunning", true);
        }
        else
        {
            currentPosIndex++;
            
            if (transform.position == targetPos)
                unitAnimator.SetBool("IsRunning", false);
        }
           
    }

    private Vector3 GetDestination()
    {
        if (currentPosIndex < pathfindingList.Count)
            return pathfindingList[currentPosIndex];

        if(currentPosIndex >= pathfindingList.Count)
        {
            currentPosIndex = 0;
            pathfindingList.Clear();
        }
            return transform.position;
    }

    public void GetTargetPos(Vector3 targetPos)
    {
        this.targetPos = targetPos;
    }

}
