using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    // Property that can be set only by this class but can be read by any other class
    public static UnitActionSystem Instance { get; private set; } 

    // EventHandler
    public event EventHandler OnSelectedUnitChanged;

    [SerializeField] private Unit selectedUnit;

    [SerializeField] private LayerMask UnitMask;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more then one UnitActionSystem! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(TurnManager.Instance.IsPlayerTurn())
            UnitSelectionCheck();

        if (!TurnManager.Instance.IsPlayerTurn())
            return;
    }

    private void UnitSelectionCheck()
    {
        if (Input.GetMouseButtonDown(0) && !(Pathfinding.Instance.isMoving))
        {
            if (TryHandleUnitSelection()) return;

            // Assigns the pathfinding position list to the selected unit, if it's player turn
            if (TurnManager.Instance.IsPlayerTurn())
                selectedUnit.GetMoveAction().SetTargetPos(Pathfinding.Instance.posList);
        }
    }
    
    // Function to check if the unit is selected
    private bool TryHandleUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycasthit, 50.0f, UnitMask))
        {
            if (raycasthit.transform.TryGetComponent<Unit>(out Unit unit)) // Returns true only if unit is selected
            {
                if (unit == selectedUnit) // Unit is already selected
                    return false;

                if (unit.IsEnemy()) // Clicked on Enemy Unit
                    return false;

                SetSelectedUnit(unit);
                return true;
            }
        }
        return false;
    }


    // Function to set selected unit
    private void SetSelectedUnit(Unit unit)
    {
        selectedUnit = unit;
        // Event
        OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty);
    }

    // Function to get selected unit
    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }
}
