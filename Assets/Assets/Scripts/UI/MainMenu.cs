using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour {

    public Animator animator;
    private int levelToLoad;
    public bool hasPressed = false;
    public GameObject mainMenu;
    public AudioSource startSound;
    public TextMeshProUGUI anyTxt;


    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Start()
    {
        //StartBlink();
    }
   
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.F10))
        {
            SceneManager.LoadScene(2);
        }

        if(Input.anyKeyDown && hasPressed == false)
        {
            hasPressed = true;
            startSound.Play();
            StartCoroutine("StartMenu");
            
        }

       /* if(Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("Filete");
            Debug.Log("Filetado");
        }*/
    }
	// Use this for initialization
	public void FadeOut ( int levelIndex)
	{
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
		
	}

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

	public void QuitGame ()
	{
		Application.Quit();
	}

   /* void StartBlink()
    {
        StopCoroutine("Blink");
        StartCoroutine("Blink");
    }

    IEnumerator Blink()
    {
        while(true)
        {
            switch(anyTxt.color.a.ToString())
            {
                case "0":
                    anyTxt.color = new Color(anyTxt.color.r, anyTxt.color.g, anyTxt.color.b, 1);

                    yield return new WaitForSeconds(0.4f);
                    break;

                case "1":
                    anyTxt.color = new Color(anyTxt.color.r, anyTxt.color.g, anyTxt.color.b, 0);

                    yield return new WaitForSeconds(0.4f);
                    break;

            }
        }
    }
    */

    public void StartBlinking()
    {
        animator.SetTrigger("Blink");
    }

    public IEnumerator StartMenu()
    {
        anyTxt.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        mainMenu.gameObject.SetActive(true);

    }

    public void FileteAnim()
    {
        animator.SetTrigger("Filete");
    }
}
