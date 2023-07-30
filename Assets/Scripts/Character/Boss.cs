using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [SerializeField] private GameObject healthText;
    private Animator anim;
    private int num1;
    private int num2;
    private int health;
    private float velocity = 0.5f;
    private Rigidbody2D rb;
    private bool isShoot;
    private bool isRage;
    private int type;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        type = Random.Range(1, 11);
        isRage = false;
        isShoot = false;
        health = Random.Range(ScoreManager.Instance.getScore()/2 + 100, ScoreManager.Instance.getScore()/2 + 130);
    }

    // Update is called once per frame
    void Update()
    {
        healthText.transform.position.Set(transform.position.x, healthText.transform.position.y, 0);
        healthText.GetComponent<TMP_Text>().text = health.ToString();
        if (isShoot == true) rb.velocity = Vector3.zero;
        else
        {
            if (isRage == true) rb.velocity = Vector2.left * 2f;
            else rb.velocity = new Vector2(-0.2f, 0);
        }
        velocity = 1f + (float)ScoreManager.Instance.getScore() / 10f;
        //transform.position = transform.position + Vector3.left * velocity * Time.deltaTime;

        if (health < 50 && type == 10)
        {
            health += 50;
            type = 1;
            anim.SetInteger("isRage", 1);
            StartCoroutine("RageRun");
        } 
            
    }

    private int Calculate(int i)
    {
        if (CalBullet.Instance.getCals(i) > 2) return health = num1 + num2;
        else return health = num1 * num2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && isRage == false)
        {
            if (Bullet.Instance.getDamage() >= health)
            {
                isShoot = true;
                anim.SetBool("isDead", true);
                StartCoroutine("CreepDie");
                ScoreManager.Instance.addScore(50);
            }
            else health -= Bullet.Instance.getDamage();
        }

    }

    private IEnumerator CreepDie()
    {
        yield return new WaitForSecondsRealtime(1f);
        gameObject.SetActive(false);
        anim.SetBool("isDead", false);
    }

    private IEnumerator RageRun()
    {
        yield return new WaitForSecondsRealtime(0.7f);
        anim.SetInteger("isRage", 2);
        isShoot = false;
        velocity = 2f;
    }

    private int min(int a, int b)
    {
        if (a > b) return a;
        return b;
    }
}
