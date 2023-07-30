using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepSpawn : MonoBehaviour
{
    [SerializeField] private GameObject creep;
    [SerializeField] private GameObject boss;
    private float timer;
    private int check;
 
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        check = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 3f)
        {
            spawnCreep();
            timer = -5f + (float) ScoreManager.Instance.getScore()/200f;
        }
        else
        {
            timer += Time.deltaTime;    
        }
    }

    public void spawnCreep()
    {
        if (ScoreManager.Instance.getScore() / 100 <= check || ScoreManager.Instance.getScore() % 100 != 0 || ScoreManager.Instance.getScore() == 0)
            Instantiate(creep, new Vector3(11, -1f, 0), transform.rotation);
        else
        {
            Instantiate(boss, new Vector3(11, -0.25f, 0), transform.rotation);
            check = ScoreManager.Instance.getScore() / 100;
        }
    }
}