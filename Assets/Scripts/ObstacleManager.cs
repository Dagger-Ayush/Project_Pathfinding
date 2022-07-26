using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] ObstacleData obsData;
    [SerializeField] string obsName;
    void Start()
    {
        // Changing the name of the obstacle in the scriptable object, using this script variable
        obsData.obstacleName = obsName; 
        Debug.Log(obsName);
    }

}
