using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isAlive;
    [SerializeField] private Animator anim;
    [SerializeField] GameObject panel;
    void Start()
    {
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Creep")
        {
            isAlive = false;
            anim.Play("Die");
            Debug.Log("Die");
            StartCoroutine("GameOver");
            
        }

    }

    public void SkillCast()
    {
        anim.Play("Cast Skill");
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSecondsRealtime(1f);
        //panel.SetActive(true);
        Debug.Log("check");
        Time.timeScale = 0;
    }
}
