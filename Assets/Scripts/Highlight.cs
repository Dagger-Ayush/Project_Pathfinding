using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    private MeshRenderer tileRend;
    public Material selectedMaterial;
    public Material defaultMaterial;
    // private bool selected;
    private bool hover;

    // Make sure the MeshRenderer component is off in the inspector

    private void Start()
    {
        tileRend = GetComponent<MeshRenderer>();
        // selected = false;
        hover = true;
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

}




