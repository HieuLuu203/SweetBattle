using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Map", menuName = "Maps")]
public class Map : ScriptableObject
{
    public string mapName;
    public GameObject mapPrefab;
    public GameObject backgroundPrefab;
    internal Vector3 localScale;
    public Image mapImage;
}
