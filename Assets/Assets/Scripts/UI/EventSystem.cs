using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventSystem : MonoBehaviour
{
    public GameObject ev;
    public GameObject startButton;
    public GameObject graphButton;

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
}
