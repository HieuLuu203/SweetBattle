using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameOverPanel instance {  get; private set; }
    [SerializeField] private Animator wrapAnimator;

    private void Awake()
    {
        instance = this; 
        

    }
    void Start()
    {
        gameObject.SetActive(true);
        

        wrapAnimator = transform.Find("Wrap").gameObject.transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        gameObject.SetActive(true);
        wrapAnimator.SetBool("isOpen", true);
    }
}
