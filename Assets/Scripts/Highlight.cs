using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    private MeshRenderer tileRend;
    // Make sure the MeshRenderer component is off in the inspector

    private void Start()
    {
        tileRend = GetComponent<MeshRenderer>();
    }

    private void OnMouseEnter()
    {
        tileRend.enabled = true;
    }

    private void OnMouseExit()
    {
        tileRend.enabled = false;
    }
}

