using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
        if (mapScriptable.Length > 0)
        {
            currentMap = mapScriptable[0];
        }
    }


    private void Start()
    {
        
    }

    

    public void SetMap(Map map)
    {
        currentMap = map;
    }


}
