using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameOverPanel instance {  get; private set; }
    private Animator wrapAnimator;
    private void Awake()
    {
        instance = this; 
    }
    void Start()
    {
        gameObject.SetActive(false);
        wrapAnimator = transform.Find("Wrap").gameObject.GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        Debug.Log("ahihi");
        gameObject.SetActive(true);
        wrapAnimator.SetBool("isOpen", true);
    }

    public void OnRePlayButton()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void OnHomeButton()
    {
        SceneManager.LoadScene("Home");
    }
}
