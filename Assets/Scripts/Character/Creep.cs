using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Creep : MonoBehaviour
{
    [SerializeField] private GameObject healthText;
    private Animator anim;
    private int num1;
    private int num2;
    private int health;
    private float velocity = 1f;
    private Rigidbody2D rb;
    private bool isShoot;
    private bool isRage;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        isRage = false;
        isShoot = false;
        int temp1, temp2;
        temp1 = Random.Range(0, 5);
        do
        {
            temp2 = Random.Range(0, 5);
        } while (temp1 == temp2);

        num1 = NumBulletSpawn.Instance.getNumber(temp1);
        num2 = NumBulletSpawn.Instance.getNumber(temp2);

        //neu ca 2 la dau tru
        if (CalBullet.Instance.getCals(0) == 5 && CalBullet.Instance.getCals(1) == 5)
        {
            //=  tong hai so
            health = max(Random.Range(num1 + num2 - 10, num1 + num2), 1);
            return;
        }
        
        for (int i = 0; i < 2; i++)
        {
            if (CalBullet.Instance.getCals(i) == 5)
            {
                health = max(Random.Range(Calculate(1 - i) - 10, Calculate(1 - i)), 1);
                return;
            }
        }
        int cal = Random.Range(0,2);
        health = max(Random.Range(max(1,Calculate(cal) - 10), Calculate(cal)), 1);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isShoot == true) rb.velocity = Vector3.zero;
        else
        {
            if (isRage == true) rb.velocity = Vector2.left * 5f;
            else
            {
                if (CreepSpawn.isSlow == true)
                {
                    anim.Play("Slow Down");
                    anim.SetBool("isSlow", true);
                    rb.velocity = Vector2.left * 0.5f;
                }
            
                else
                {
                    anim.SetBool("isSlow", false);
                    rb.velocity = Vector2.left * velocity;
                }
            }
        }

        healthText.transform.position.Set(transform.position.x, healthText.transform.position.y, 0);
        healthText.GetComponent<TMP_Text>().text = health.ToString();
        //velocity = 1f + (float)ScoreManager.Instance.getScore() / 300f;
        //transform.position = transform.position + Vector3.left * velocity * Time.deltaTime;
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
                anim.Play("Creep Die");
                anim.SetBool("isDead", true);
                StartCoroutine("CreepDie");
                ScoreManager.Instance.addScore(10);
            }
            else
            {
                if (CalBullet.Instance.getCalculation() == 5) health -= Bullet.Instance.getDamage();
                else
                {
                    isShoot = true;
                    isRage = true;
                    anim.Play("Rage When Hit");
                    StartCoroutine("RageRun");
                }
            } 
                
        }

        if (collision.gameObject.tag == "Penetrate" && isRage == false)
        {
            isShoot = true;
            anim.Play("Creep Die");
            anim.SetBool("isDead", true);
            StartCoroutine("CreepDie");
            ScoreManager.Instance.addScore(10);
        }
    }

    private IEnumerator CreepDie()
    {
        yield return new WaitForSecondsRealtime(0.8f);
        gameObject.SetActive(false);
        anim.SetBool("isDead", false);
    }

    private IEnumerator RageRun()
    {
        yield return new WaitForSecondsRealtime(0.7f);
        anim.SetInteger("isRage", 2);
        isShoot = false;
        velocity = 5f;
    }

     

    private int max (int a, int b)
    {
        if (a > b) return a;
        return b;
    }
    //public void Slow()
    //{
    //    StartCoroutine("Slow");
    //}
    //IEnumerator SlowDelay(Animator anim)
    //{
    //    anim.SetBool("isSlow", true);
    //    yield return new WaitForSecondsRealtime(3.5f);
    //    anim.SetBool("isSlow", false);
    //    yield return null;
    //}
}
