using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Animator animator;
    
    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


   
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.F10))
        {
            SceneManager.LoadScene(2);
        }
    }
	// Use this for initialization
	public void FadeOut ()
	{
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
}
