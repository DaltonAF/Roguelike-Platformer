using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    public AudioSource _AudioSource1;
    public AudioSource _AudioSource2;


    void Start()
    {
        _AudioSource1.Play();
    }

    void Update()
    {
        if(DeathSceneScript.isDead)
        {
            if(_AudioSource1.isPlaying)
            {
            _AudioSource1.Stop();

            _AudioSource2.Play();
            }
        }

    }
}
