using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SplashSequence : MonoBehaviour {

    public Image splashImage;
    public string loadlevel;
    public AudioSource logoFX;

    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.F10))
        {
            SceneManager.LoadScene(1);
        }
    }

    IEnumerator Start()
    {
        splashImage.canvasRenderer.SetAlpha(0.0f);

        FadeIn();
        logoFX.Play();
        yield return new WaitForSeconds(2.5f);
        FadeOut();
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(1);
    }

    void FadeIn()
    {
        splashImage.CrossFadeAlpha(1.0f, 1.5f, false);
    }

    void FadeOut()
    {
        splashImage.CrossFadeAlpha(0.0f, 2.5f, false);
    }

}
