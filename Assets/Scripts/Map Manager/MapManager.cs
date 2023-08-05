using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;
    public Map[] mapScriptable;
    public Map currentMap;

    private void Awake()
    {
        
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }


    private void Start()
    {
        if(mapScriptable.Length > 0)
        {
            currentMap = mapScriptable[0];
        }
    }

    public void SetMap(Map map)
    {
        currentMap = map;
    }


}
