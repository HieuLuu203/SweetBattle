using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public static Bullet Instance;
    private int damage;
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rigidbody;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        damage = 0;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    private void OnEnable()
    {
        transform.position = new Vector3(-6f, -1, 0);
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    // hàm bắn đạn sau khi thực hiện xong tính toán
    public void ShootBullet()
    {
        if (!CalBullet.Instance.CalBulletReady() || !NumBulletSpawn.Instance.NumBulletReady())
            return;
        GetComponent<SpriteRenderer>().enabled = true;
        this.gameObject.SetActive(true);
        
        rigidbody.velocity = Vector2.right * 25;
        CalBullet.Instance.Shooting();
        NumBulletSpawn.Instance.Shooting();
        switch (CalBullet.Instance.getCalculation())
        {
            case 1:
                damage = NumBulletSpawn.Instance.getNumber(NumBulletSpawn.Instance.numberChosen1) * NumBulletSpawn.Instance.getNumber(NumBulletSpawn.Instance.numberChosen2);
                break;
            case 2:
                damage = NumBulletSpawn.Instance.getNumber(NumBulletSpawn.Instance.numberChosen1) * NumBulletSpawn.Instance.getNumber(NumBulletSpawn.Instance.numberChosen2);
                break;
            case 3:
                damage = NumBulletSpawn.Instance.getNumber(NumBulletSpawn.Instance.numberChosen1) + NumBulletSpawn.Instance.getNumber(NumBulletSpawn.Instance.numberChosen2);
                break;
            case 4:
                damage = NumBulletSpawn.Instance.getNumber(NumBulletSpawn.Instance.numberChosen1) + NumBulletSpawn.Instance.getNumber(NumBulletSpawn.Instance.numberChosen2);
                break;
            case 5:
                damage = NumBulletSpawn.Instance.getNumber(NumBulletSpawn.Instance.numberChosen1);
                break;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border") 
            transform.gameObject.SetActive(false);
        if (collision.gameObject.tag == "Creep")
        {
            anim.SetBool("isTouched", true);
            rigidbody.velocity = Vector3.left * 0.5f;
            StartCoroutine("Reset");


            //SLOWDOWN
    
            //Animator creepAnim = collision.gameObject.GetComponent<Animator>();

            //StartCoroutine("SlowDelay", creepAnim);
        }

    }

    public int getDamage()
    {
        //Debug.Log(NumBulletSpawn.Instance.getNumber(NumBulletSpawn.Instance.numberChosen1));
        //Debug.Log(NumBulletSpawn.Instance.getNumber(NumBulletSpawn.Instance.numberChosen2));
        return damage;
    }

    public bool GetActive()
    {
        return gameObject.activeSelf;
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        gameObject.SetActive(false);
    }


}
