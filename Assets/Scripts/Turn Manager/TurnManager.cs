using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance { get; private set; }

    public event EventHandler OnTurnChanged;
    // Player's First Turn By Default
    private bool isPlayerTurn = true;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more then one TurnManager! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // Function to get player turn
    public bool IsPlayerTurn()
    {
        return isPlayerTurn;
    }

    public void NextTurn()
    {
        isPlayerTurn = !isPlayerTurn;

        OnTurnChanged?.Invoke(this, EventArgs.Empty);
    }
}
