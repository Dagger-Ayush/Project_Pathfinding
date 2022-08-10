using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private Animator unitAnimator;

    private Vector3 targetPos;
    readonly private float moveSpeed = 4.0f;
    readonly private float stopDis = 0.1f;

    private void Awake()
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

            unitAnimator.SetBool("IsWalking", true);
        }
        else
            unitAnimator.SetBool("IsWalking", false);

        if (Input.GetMouseButtonDown(0))
            Move(MouseWorld.GetPositionOnGround());
    }

    private void Move(Vector3 targetPos)
    {
        this.targetPos = targetPos;
    }
}
