using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private Animator unitAnimator;

    readonly private float moveSpeed = 3.0f;
    readonly private float stopDis = 0.1f;

    private Vector3 targetPos;

    void Awake()
    {
       targetPos = transform.position;
    }

    private void Update()
    {

        if (Vector3.Distance(transform.position, targetPos) > stopDis)
        {
            Vector3 moveDirection = (targetPos - transform.position).normalized;
            transform.position += moveSpeed * Time.deltaTime * moveDirection;
            transform.forward = moveDirection;

            unitAnimator.SetBool("IsRunning", true);
        }
        else
            unitAnimator.SetBool("IsRunning", false);
    }

    public void GetTargetPos(Vector3 targetPos)
    {
        this.targetPos = targetPos;
    }

}
