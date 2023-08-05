using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumBulletSpawn : MonoBehaviour
{
    public static NumBulletSpawn Instance;
    private int maxClickButton;

    private Queue<int> randomNumber = new Queue<int>();
    private Queue<int> buttonsClicked = new Queue<int>();
    private int[] number = new int[5];
    private bool[] isClicked = new bool[5];
    public int numberChosen1;
    public int numberChosen2;

    [SerializeField] private GameObject[] button;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(this);
    }
    private void OnEnable()
    { 
        for (int i = 0; i < 5; i++)
        {
            randomNumber.Enqueue(Random.Range(1, 10)); // đẩy số random vào queue;
        }
        
    }

    private void Start()
    {
        
        for (int i = 0; i < 5; i++)
        {
            //randomNumber.Enqueue(Random.Range(1, 10));
            if (randomNumber.Count != 0)
            {
                number[i] = randomNumber.Peek(); //Đẩy số ở đỉnh queue vào button
                randomNumber.Dequeue(); // Đẩy thêm 1 số random vào queue
            }
        }

        for (int i = 0; i < 5; i++)
        {
            button[i].GetComponentInChildren<TextMeshProUGUI>().text = number[i].ToString(); // Hiện số ở trên button
            isClicked[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CalBullet.Instance.getCalculation() == 5)
        {
            maxClickButton = 1;
        }
        else maxClickButton = 2;
            for (int i = 0; i < 5; i++)
        {
            if (isClicked[i] == true)
            {
                button[i].GetComponent<Image>().sprite = UIManager.Instance.clickedButton;
            }
            else
            {
                button[i].GetComponent<Image>().sprite = UIManager.Instance.canClickButton;
            }
        }

        
    }

    public void ButtonClick(int option)
    {
        if (isClicked[option] == false)
        {
            PlaySound.Instance.BulletButton();
            if (buttonsClicked.Count < maxClickButton)
            {
                numberChosen1 = option;
                buttonsClicked.Enqueue(option);
                if (buttonsClicked.Count == 2) numberChosen2 = buttonsClicked.Peek();
            }
            else
            {
                isClicked[buttonsClicked.Peek()] = false;
                numberChosen1 = option;
                buttonsClicked.Dequeue();
                buttonsClicked.Enqueue(option);
                numberChosen2 = buttonsClicked.Peek();
            }
            isClicked[option] = true;
        }
    }

    public void Shooting()
    {
        StartCoroutine("Reset");
    }

    public bool NumBulletReady()
    {
        if (buttonsClicked.Count == 1 && CalBullet.Instance.getCalculation() == 5) return true;
        if (buttonsClicked.Count == 2) return true;
        return false;
    }    

    public int getClicked()
    {
        return buttonsClicked.Count;
    }

    public int getNumber(int i)
    {
        return number[i];
    }

    private IEnumerator Reset()
    {
        yield return new WaitUntil(() => Bullet.Instance.gameObject.activeSelf == false);
        while (buttonsClicked.Count > 0)
        {
            int temp = buttonsClicked.Peek();
            isClicked[temp] = false;
            buttonsClicked.Dequeue();
            number[temp] = Random.Range(1, 10 + (int) ScoreManager.Instance.getScore() / 50);
        }
        for (int i = 0; i < 5; i++)
        {
            button[i].GetComponentInChildren<TextMeshProUGUI>().text = number[i].ToString(); // Hiện số ở trên button
            button[i].SetActive(true);
        }
    }

    public void UnCLick()
    {
        while (buttonsClicked.Count > 0)
        {
            int temp = buttonsClicked.Peek();
            isClicked[temp] = false;
            buttonsClicked.Dequeue();
        }
    }    
}
