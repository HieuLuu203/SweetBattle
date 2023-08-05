using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SlowDownButton : MonoBehaviour {

    private float timeTilNext;
    private float timeCurrent;
    void Start()
    {
        PlayerPrefs.SetInt("isCanSlow", 1);
        timeTilNext = 30.0f;//const
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("isCanSlow") == 0)
        {
            
            timeCurrent += Time.deltaTime;
            gameObject.GetComponent<Image>().fillAmount = timeCurrent / timeTilNext;
        }
        if(timeCurrent > timeTilNext)
        {
            PlayerPrefs.SetInt("isCanSlow", 1);
        }

    }

    public void OnSlowDownButton()
    {
        
            if (PlayerPrefs.GetInt("isCanSlow") == 1)
            {
                timeCurrent = 0.0f;
                PlayerPrefs.SetInt("isCanSlow", 0);
            }
     
        
    }


}

   