using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using System.Collections;

public class QuitDemo : MonoBehaviour
{
    public GameObject DemoText;
    bool Active = false;

    void Start()
    {
        DemoText.SetActive(false);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (Active == false)
        {
            Active = true;
            DemoText.SetActive(true);
            StartCoroutine(SelfDestruct());
        }
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSecondsRealtime(5);
        StartCoroutine(Five());
    }

    IEnumerator Five()
    {
        DemoText.GetComponent<Text>().text = "This demo will self destruct in 5";
        yield return new WaitForSecondsRealtime(1);
        StartCoroutine(Four());
    }

    IEnumerator Four()
    {
        DemoText.GetComponent<Text>().text = "This demo will self destruct in 4";
        yield return new WaitForSecondsRealtime(1);
        StartCoroutine(Three());
    }

    IEnumerator Three()
    {
        DemoText.GetComponent<Text>().text = "This demo will self destruct in 3";
        yield return new WaitForSecondsRealtime(1);
        StartCoroutine(Two());
    }

    IEnumerator Two()
    {
        DemoText.GetComponent<Text>().text = "This demo will self destruct in 2";
        yield return new WaitForSecondsRealtime(1);
        StartCoroutine(One());
    }

    IEnumerator One()
    {
        DemoText.GetComponent<Text>().text = "This demo will self destruct in 1";
        yield return new WaitForSecondsRealtime(1);
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
