using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private MoveAction moveAction;
    [SerializeField] private bool isEnemy;

    private void Awake()
    {
        moveAction = GetComponent<MoveAction>();
    }

    public MoveAction GetMoveAction()
    {
        return moveAction;
    }

    public bool IsEnemy()
    {
        return isEnemy;
    }

}
