using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectedVusual : MonoBehaviour
{
    [SerializeField] private Unit unit;

    private MeshRenderer selectedRenderer;

    private void Awake()
    {
        selectedRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        // Subscribing to the event
        UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;
        UpdateVisual();
    }

    // Subsriber Or Listener
    private void UnitActionSystem_OnSelectedUnitChanged(object sender, EventArgs empty)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        if (UnitActionSystem.Instance.GetSelectedUnit() == unit)
            selectedRenderer.enabled = true;
        else
            selectedRenderer.enabled = false;
    }
}
