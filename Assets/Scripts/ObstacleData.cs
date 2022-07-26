using UnityEngine;
using Unity.Collections;

[CreateAssetMenu(fileName = "ObstacleData")]
public class ObstacleData : ScriptableObject
{
    public GameObject obstacle;
    public string obstacleName;
}
