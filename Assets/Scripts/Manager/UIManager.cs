using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static UIManager Instance;
    public Sprite cantClickButton;
    public Sprite clickedButton;
    public Sprite canClickButton;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(this);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
