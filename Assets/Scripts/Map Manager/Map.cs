using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Map", menuName = "Maps")]
public class Map : ScriptableObject
{
    public string mapName;
    public Image mapButton;
    internal Vector3 localScale;
    public Image mapImage;
    public bool isLock;
    public GameObject lockPrefab;
}
