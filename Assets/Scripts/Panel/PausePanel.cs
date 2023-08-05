using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    // Start is called before the first frame update
    public static PausePanel instance { get; private set; }
    private Animator popupAnimator;
    private GameObject SettingPanel;
    private Animator settingPanelAnimator;
    
    private void Awake()
    {
        instance = this; 
    }
    void Start()
    {
        gameObject.SetActive(false);
        popupAnimator = transform.Find("Pop Up").gameObject.GetComponent<Animator>();
        SettingPanel = transform.Find("SettingPanel").gameObject;
        SettingPanel.SetActive(false);
        settingPanelAnimator = SettingPanel.transform.Find("Board").gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        Debug.Log("Pause");
        Time.timeScale = 0;
        gameObject.SetActive(true);
        popupAnimator.SetBool("isOpen", true);
    }

    public void OnHomeButton()
    {
        Time.timeScale = 1;
        MusicManager.Instance.music[1].Stop();
        MusicManager.Instance.music[0].Play();
        SceneManager.LoadScene("Home");
    }

    public void OnContinueButton()
    {
        Time.timeScale = 1;
        popupAnimator.SetBool("isOpen", false);
        gameObject.SetActive(false);
    }
    public void OnSettingButton()
    {
        SettingPanel.SetActive(true);
        settingPanelAnimator.SetBool("isOpen", true);
    }
}
