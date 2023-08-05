using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        gameObject.SetActive(true);
        StartCoroutine("EndGame");
    }

    public void OnRePlayButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GamePlay");
    }

    public void OnHomeButton()
    {
        MusicManager.Instance.music[1].Stop();
        MusicManager.Instance.music[0].Play();
        SceneManager.LoadScene("Home");
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        GetComponent<Image>().color = new Color32(56, 56, 56, 136);
        wrapAnimator.SetBool("isOpen", true);
        Time.timeScale = 0;
        PlaySound.Instance.GameOver();
    }    
}
