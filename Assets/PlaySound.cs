using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public static PlaySound Instance;
    [SerializeField] private AudioClip[] clip;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(this);
    }

    // Update is called once per frame

    public void NormalButton()
    {
        MusicManager.Instance.PlaySound(clip[0], 0);
    }

    public void BulletButton()
    {
        MusicManager.Instance.PlaySound(clip[1], 1);
    }

    public void GameOver()
    {
        MusicManager.Instance.PlaySound(clip[2], 2);
    }
}
