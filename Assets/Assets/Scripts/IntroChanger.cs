using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Change");
    }

    // Update is called once per frame
    IEnumerator Change()
    {
        yield return new WaitForSeconds(23);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
