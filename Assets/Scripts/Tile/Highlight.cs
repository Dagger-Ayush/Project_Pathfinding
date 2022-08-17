using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    private MeshRenderer tileRend;

    private void Awake()
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




