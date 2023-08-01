using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlowDownButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Camera MainCamera;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnSlowDownButton()
    {
        GameObject[] creeps = GameObject.FindGameObjectsWithTag("Creep");

        foreach (GameObject creep in creeps)
        {
            Renderer renderer = creep.GetComponent<Renderer>();

            if (renderer != null && renderer.isVisible)
            {
                Animator anim = creep.GetComponent<Animator>();
                StartCoroutine("SetAnimSlow",anim);
            }
        }
    }

    IEnumerator SetAnimSlow(Animator anim)
    {
        anim.SetBool("isSlow", true);
        yield return new WaitForSecondsRealtime(3.5f);
        anim.SetBool("isSlow", false);
    }
}