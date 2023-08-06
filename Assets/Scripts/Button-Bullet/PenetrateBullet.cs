using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenetrateBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine("DelayTime");
    }

    IEnumerator DelayTime()
    {
        yield return new WaitForSecondsRealtime(0.8f);
        GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSecondsRealtime(0.8f);
        this.gameObject.SetActive(false);
    }
}
