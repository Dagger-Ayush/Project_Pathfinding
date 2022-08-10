using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    private MeshRenderer tileRend;

    public Material selectedMaterial;
    public Material currentMaterial;
    public Material targetMaterial;
    public Material defaultMaterial;

    //[SerializeField] private bool current = false;
    //[SerializeField] private bool selectable = false;
    //[SerializeField] private bool target = false;

    public bool hover = true;
    public bool selected = false;
    // Make sure the MeshRenderer component is off in the inspector

    private void Start()
    {
        tileRend = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        // TileOperatioin();
    }

    private void OnMouseEnter()
    {
        if(hover)
        tileRend.enabled = true;
    }

    private void OnMouseExit()
    {
        if(hover)
        tileRend.enabled = false;
    }

    //void TileOperatioin()
    //{
    //    if(Input.GetKeyDown(KeyCode.Mouse0))
    //    {
    //        hover = !hover;
    //        selected = !selected;
    //    }
        
    //    if (selected)
    //    {
    //        if (current)
    //            tileRend.material = currentMaterial;
    //        else if (target)
    //            tileRend.material = targetMaterial;
    //        else if (selectable)
    //            tileRend.material = selectedMaterial;
    //        else
    //            tileRend.material = defaultMaterial;
    //    }
    //}
        
    
}




