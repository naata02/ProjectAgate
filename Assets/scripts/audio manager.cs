using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    public AudioSource bgmAudiosource;
    public GameObject sfxAudiosource;

    private void Start()
    {
        PlayBGM();
    }
     
    private void PlayBGM()
    {
        bgmAudiosource.Play();
    }

     public void playSFX(Vector3 spawnposition)
    {
        GameObject.Instantiate(sfxAudiosource, spawnposition, Quaternion.identity);
    }
}
