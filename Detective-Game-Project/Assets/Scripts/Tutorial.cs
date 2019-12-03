using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject Tutorialpanel;
    public GameObject Tutorialstart;

    public GameObject TutorialItem = null;

    // Start is called before the first frame update
    void Start()
    {
        Tutorialpanel.SetActive(true);
        Tutorialstart.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume()
    {
        Tutorialpanel.SetActive(false);
        Tutorialstart.SetActive(false);
        if (TutorialItem != null)
        {
            TutorialItem.SetActive(false);
        }
        Time.timeScale = 1;
    }

    private void OnTriggerEnter(Collider collision)
        {
            if (collision.tag == "Tutorial")
            {
                if (collision.GetComponent<TutorialItem>().done == false)
                {
                    Tutorialpanel.SetActive(true);
                    TutorialItem = collision.GetComponent<TutorialItem>().tutorialtrigger;
                    collision.GetComponent<TutorialItem>().tutorialtrigger.SetActive(true);
                    collision.GetComponent<TutorialItem>().done = true;
                    Time.timeScale = 0;
                }
            }
        }
}
