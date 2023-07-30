using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tip : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] private Animator animator;
    private TextMeshProUGUI textMesh;

    private string[] Tips = new string[8];

    void Start()
    {
        Tips[1] = "Tip: Tính vừa đủ, để dành những số to và phép nhân cho phép tính sau";
        Tips[2] = "Tip: Có thể dùng dấu trừ để loại bỏ các số nhỏ";
        Tips[3] = "Tip: Với cùng một tổng thì cặp hai số có hiệu nhỏ hơn sẽ có tích lớn hơn";
        int n = Random.Range(1, 4);
        Debug.Log(n);
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.text = Tips[n];

        StartCoroutine("Delay");


    }

    // Update is called once per frame

    void Update()
    {

    }

    IEnumerator Delay()
    {
        //animator.SetBool("isAppear", true);
        yield return new WaitForSeconds(4.2f);
        SceneManager.LoadScene("GamePlay");
        //animator.SetBool("isAppear", false);
    }

}
