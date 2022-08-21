using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public bool enemyTurnCompelted;
    float timer;

    public static EnemyAI Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        TurnManager.Instance.OnTurnChanged += TurnManager_OnTurnChanged;
    }
    private void Update()
    {
        if (TurnManager.Instance.IsPlayerTurn())
            return;

        timer -= Time.deltaTime;

        if (timer <= 0 && enemyTurnCompelted && !Pathfinding.Instance.isMoving)
            TurnManager.Instance.NextTurn();
    }

    // Startpos for pathfinding of enemy
    public Vector3 SetStartPosForEnemy()
    {
        return transform.position;
    }

    // Function to get 'targetPos' for EnemyAI
    public Vector3 GetDestinationForEnemy()
    {
        Vector3 posS = transform.position;

        Vector3 frontPos = UnitActionSystem.Instance.GetSelectedUnit().transform.position + new Vector3(2, 0, 0); // Front
        float frontDistance = Vector3.Distance(posS, frontPos);

        Vector3 backPos = UnitActionSystem.Instance.GetSelectedUnit().transform.position - new Vector3(2, 0, 0); // Back
        float backDistance = Vector3.Distance(posS, backPos);

        Vector3 leftPos = UnitActionSystem.Instance.GetSelectedUnit().transform.position + new Vector3(0, 0, 2); // Left
        float leftDistance = Vector3.Distance(posS, leftPos);

        Vector3 rightPos = UnitActionSystem.Instance.GetSelectedUnit().transform.position - new Vector3(0, 0, 2); // Right
        float rightDistance = Vector3.Distance(posS, rightPos);

        if (frontDistance < backDistance && frontDistance < rightDistance && frontDistance < leftDistance)
            return frontPos;
        else if (backDistance < frontDistance && backDistance < rightDistance && backDistance < leftDistance)
            return backPos;
        else if (leftDistance < backDistance && leftDistance < rightDistance && leftDistance < rightDistance)
            return leftPos;
        else
            return rightPos;

    }

    // 'enemyTurnCompleted' turns true from the movement it's Enemy Turn,
    // hence a delay is added so the enemy gets moving and the above condition for 'NextTurn()' does not hold true till the enemy reaches it's target position
    private void TurnManager_OnTurnChanged(object sender, EventArgs e)
    {
        timer = 2f;
    }
}
