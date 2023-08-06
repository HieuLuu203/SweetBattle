using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SlowDownButton : MonoBehaviour {

    private bool isCanSlow;
    public static SlowDownButton instance {  get; private set; }
    private float timeTilNext;
    [SerializeField] private float timeCurrent;
    private Image slow;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

        isCanSlow = true;
        timeTilNext = 30.0f;//const
        slow = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isCanSlow == false)
        {
          
            timeCurrent += Time.deltaTime;
            slow.fillAmount = timeCurrent / timeTilNext;
            if (timeCurrent > timeTilNext)
            {
                isCanSlow = true;
            }
        }
        //if (timeCurrent == 0f)
        //{
        //    isCanSlow = false;
        //}


    }

    public void OnSlowDownButton()
    {
        timeCurrent = 0.0f;
        isCanSlow = false;

    }

    public bool getIsCanSlow()
    {
        return isCanSlow;
    }


}

   