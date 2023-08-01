using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireButton : MonoBehaviour
{
    [SerializeField] private Sprite attack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CalBullet.Instance.CalBulletReady() && NumBulletSpawn.Instance.NumBulletReady())
        {
            GetComponent<Image>().sprite = attack;
        }
        else
        {
            GetComponent<Image>().sprite = UIManager.Instance.cantClickAttack;
        }
    }
}
