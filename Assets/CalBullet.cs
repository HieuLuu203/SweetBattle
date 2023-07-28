using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalBullet : MonoBehaviour
{
    public static CalBullet Instance;

    private int calculation;
    private int buttonClicked;
    private bool shoot;
    [SerializeField] private TextMeshProUGUI button1;
    [SerializeField] private TextMeshProUGUI button2;
    [SerializeField] private Button[] button;
    
    private Queue<int> randomCaculation = new Queue<int>(); // Lưu các số đại diện cho các phép tính: 1-nhân, 2-cộng, 3-trừ
    private int[] cals = new int[2]; // Lưu phép tính gắn với các button dưới dạng số


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        calculation = 0;
        buttonClicked = -1;
        shoot = false;
        Push(5);
        cals[0] = randomCaculation.Peek();
        ChangeImageButton(button1, cals[0]);
        randomCaculation.Dequeue();
        cals[1] = randomCaculation.Peek();
        ChangeImageButton(button2, cals[1]);
        randomCaculation.Dequeue();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 2; i++)
        {
            if (cals[i] == 5 && NumBulletSpawn.Instance.getClicked() == 2)
            {
                button[i].GetComponent<Image>().sprite = UIManager.Instance.cantClickButton;
                continue;
            }
            if (i == buttonClicked) button[i].GetComponent<Image>().sprite = UIManager.Instance.clickedButton;
            else button[i].GetComponent<Image>().sprite = UIManager.Instance.canClickButton;
        }


        
    }

    public void Click(int button)
    {
        if (cals[button] == 5 && NumBulletSpawn.Instance.getClicked() == 2) return;
        buttonClicked = button;
        calculation = cals[button];
    }

    // Đẩy số random vào trong queue;
    private void Push(int n)
    {
        for (int i = 0; i < n; i++)
            randomCaculation.Enqueue(Random.Range(1, 6));
    }

    private void ChangeImageButton(TextMeshProUGUI button, int option)
    {
        switch (option)
        {
            case 1:
                button.text = "x";
                break;
            case 2:
                button.text = "x";
                break;
            case 3:
                button.text = "+";
                break;
            case 4:
                button.text = "+";
                break;
            case 5:
                button.text = "-";
                break;
        }
    }

    public void Shooting()
    {
        StartCoroutine("Reset");
    }

    public bool CalBulletReady()
    {
        if (buttonClicked == -1) return false;
        return true;
    }

    public int getCalculation()
    {
        return calculation;
    }

    public int getCals(int i)
    {
        return cals[i];
    }

    private IEnumerator Reset()
    {
        yield return new WaitUntil(() => Bullet.Instance.gameObject.activeSelf == false);
        TextMeshProUGUI tempButton;
        if (buttonClicked == 0) tempButton = button1;
        else tempButton = button2;
        Push(1);
        if (randomCaculation.Count > 0) cals[buttonClicked] = randomCaculation.Peek();
        randomCaculation.Dequeue();
        ChangeImageButton(tempButton, cals[buttonClicked]);
        shoot = false;
        buttonClicked = -1;
        calculation = 0;
    }   
}
