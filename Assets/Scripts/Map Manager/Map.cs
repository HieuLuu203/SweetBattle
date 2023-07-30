using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Map", menuName = "Maps")]
public class Map : ScriptableObject
{
    [SerializeField] string mapName;
    [SerializeField] GameObject mapPrefab;

}
