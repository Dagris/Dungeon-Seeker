using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EventSystem : MonoBehaviour
{
    public GameObject ev;
    public GameObject startButton;
    public GameObject graphButton;
    public GameObject videoButton;
    public GameObject volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        ev = GameObject.Find("EventSystem");
    }

    public void FirstStart()
    {
        //optionMenu.SetActive(false);
        //mainMenu.SetActive(true);
        //ev.GetComponent<UnityEngine.EventSystems.EventSystem>().firstSelectedGameObject = startButton;
        ev.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject (startButton);
        
    }

    public void FirstGraph()
    {
        //ev.GetComponent<UnityEngine.EventSystems.EventSystem>().firstSelectedGameObject = graphButton;
        ev.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(graphButton);
    }

    public void FirstVideo()
    {
        //ev.GetComponent<UnityEngine.EventSystems.EventSystem>().firstSelectedGameObject = graphButton;
        ev.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(videoButton);
    }

    public void FirstVolume()
    {
        //ev.GetComponent<UnityEngine.EventSystems.EventSystem>().firstSelectedGameObject = graphButton;
        ev.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(volumeSlider);
    }
}
