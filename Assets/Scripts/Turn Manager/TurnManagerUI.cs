using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TurnManagerUI : MonoBehaviour
{
    [SerializeField] private Button endTurnButton;

    private void Start()
    {
        endTurnButton.onClick.AddListener(() =>
        {
            TurnManager.Instance.NextTurn();

        });
    }

    private void Update()
    {
        endTurnButton.gameObject.SetActive(TurnManager.Instance.IsPlayerTurn() && !Pathfinding.Instance.isMoving);
    }

}
