using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitEnemyVisual : MonoBehaviour
{
    private MeshRenderer visual;
    void Start()
    {
        visual = GetComponent<MeshRenderer>();
    }

    
    void Update()
    {
        if (!TurnManager.Instance.IsPlayerTurn())
            visual.enabled = true;
        else
            visual.enabled = false;
    }
}
