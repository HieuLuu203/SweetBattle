using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelector : MonoBehaviour
{
    public GameObject optionPrefab;
    public GameObject lockPrefab;

    public Transform prevMap;
    public Transform selectedMap;

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        foreach (Map m in MapManager.Instance.mapScriptable)
        {
            if (PlayerPrefs.GetInt("Highscore") >= 300 && m==MapManager.Instance.mapScriptable[1]) m.isLock = false;
            if (PlayerPrefs.GetInt("Highscore") >= 600 && m == MapManager.Instance.mapScriptable[2]) m.isLock = false;
            GameObject option;
            if (m.isLock)
            {
                option = Instantiate(m.lockPrefab, transform);
            }
            else
            {
                option = Instantiate(optionPrefab, transform);
            }
            Button button = option.GetComponent<Button>();

            if (!m.isLock)
            {
                button.onClick.AddListener(() =>
                {
                    MapManager.Instance.SetMap(m);
                    if (selectedMap != null)
                    {
                        prevMap = selectedMap;
                    }
                    selectedMap = option.transform;
                });
            }
            Image image = option.GetComponentInChildren<Image>();
            image.sprite = m.mapButton.sprite;


        }
    }

    private void Update()
    {
        if(selectedMap != null)
        {
            selectedMap.localScale = Vector3.Lerp(selectedMap.localScale, new Vector3(1.2f, 1.2f, 1.2f), Time.deltaTime * 10);
            Debug.Log("1");
        }
        if (prevMap != null)
        {
            prevMap.localScale = Vector3.Lerp(prevMap.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10);
        }

    }

    public void Load()
    {

    }
}
