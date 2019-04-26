using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource buttonFx;
    public AudioClip selectionSound;
    
    public void SelectionFx()
    {
        buttonFx.PlayOneShot(selectionSound);
    }
}
