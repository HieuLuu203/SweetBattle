using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Instantiate(MapManager.Instance.currentMap.mapPrefab, transform.position, Quaternion.identity);
    }
}
