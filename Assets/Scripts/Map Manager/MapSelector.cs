using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelector : MonoBehaviour
{
    public GameObject optionPrefab;

    public Transform prevMap;
    public Transform selectedMap;

    private void Start()
    {
        foreach(Map m in MapManager.Instance.mapScriptable)
        {
            GameObject option = Instantiate(optionPrefab, transform);
            Button button = option.GetComponent<Button>();

            button.onClick.AddListener(() =>
            {
                MapManager.Instance.SetMap(m);
                if(selectedMap != null )
                {
                    prevMap = selectedMap;
                }
                selectedMap = option.transform;
            });

            GameObject mapSprite = option;


        }
    }
    private void Update()
    {
        if(selectedMap != null)
        {
            selectedMap.localScale = Vector3.Lerp(selectedMap.localScale, new Vector3(1.2f, 1.2f, 1.2f), Time.deltaTime * 10);

        }
        if (prevMap != null)
        {
            selectedMap.localScale = Vector3.Lerp(selectedMap.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10);
        }

    }
}
