using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseAudio;

    public GameObject pasueMenuUI;

    public Button resume;

   

    private void Start()
    {
        GameIsPaused = false;

        pauseAudio = GameObject.FindGameObjectWithTag("AudioManager");
    }
    // Update is called once per frame
    void Update ()
    {
		if (Input.GetButtonDown("P"))
        {

            if(GameIsPaused)
            {
                Resume();
                Debug.Log("resumed");
            }

            else
            {
                Pause();
                Debug.Log("paused");
            }

            
        }

        if (Input.GetButtonDown("B"))
        {

            resume.onClick.Invoke();
        }
    }
    
    public void Resume ()
    {
        pasueMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseAudio.GetComponent<AudioManager>().SetPitchNormal();
    }

    void Pause ()
    {
        pasueMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        pauseAudio.GetComponent<AudioManager>().SetPitchDown();

    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
