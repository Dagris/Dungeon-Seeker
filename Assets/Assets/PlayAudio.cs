using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource intro;
    // Start is called before the first frame update
    void Start()
    {
        intro.Play();
    }

}
