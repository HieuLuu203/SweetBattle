using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Map", menuName = "Maps")]
public class Map : ScriptableObject
{
    public string mapName;
    public GameObject mapPrefab;

}
