using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image backgroundImage;
    private void Start()
    {
        //Instantiate(MapManager.Instance.currentMap.backgroundPrefab, transform.position, Quaternion.identity);
        backgroundImage.sprite = MapManager.Instance.currentMap.mapImage.sprite;
    }
}
