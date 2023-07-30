using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private Rigidbody2D rb;
    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Bullet.Instance.gameObject.activeSelf == false) gameObject.SetActive(false);    
    }

    private void OnEnable()
    {
        score.gameObject.transform.position = new Vector3(-6, 1, 0);
        rb.velocity = new Vector2 (3,3);
        score.text = Bullet.Instance.getDamage().ToString();
    }
}
