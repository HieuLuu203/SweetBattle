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
            Debug.Log("co map");
            currentMap = mapScriptable[0];
            //currentMap.localScale = Vector3.Scale(new Vector3(1f, 1f, 1f), new Vector3(1.2f, 1.2f, 1.2f));
        }
        else
        {
            Debug.Log("khong co map");
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
