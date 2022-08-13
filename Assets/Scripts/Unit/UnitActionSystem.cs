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
        if (Input.GetMouseButtonDown(0))
        {
            if (TryHandleUnitSelection()) return;

            selectedUnit.GetTargetPos(MouseWorld.GetPositionOnGround());
        }
           
    }

    private bool TryHandleUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycasthit, 50.0f, UnitMask))
        {
            if (raycasthit.transform.TryGetComponent<Unit>(out Unit unit)) // Returns true only if unit is selected
            {
                SetSelectedUnit(unit);
                return true;
            }
        }
        return false;
    }

    private void SetSelectedUnit(Unit unit)
    {
        selectedUnit = unit;
        // Event
        OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty);
    }

    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }
}
