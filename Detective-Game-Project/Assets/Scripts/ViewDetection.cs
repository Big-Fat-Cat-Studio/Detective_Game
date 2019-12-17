using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewDetection : MonoBehaviour
{
    public bool disabled;
    public bool detectOnlyHuman;

    public Transform Human;
    private bool humanDetected;
    private bool humanInView;

    public Transform Dog;
    private bool dogDetected;
    private bool dogInView;

    private bool inView;

    public void inFov(Transform target, string tag)
    {
        RaycastHit hit;
        float offset = (tag == "Human" ? 1.5f : 0.5f);
        Vector3 direction = (target.position + Vector3.up * offset);

        if(Physics.Linecast(transform.position, direction, out hit))
        {
            if (tag == "Animal")
            {
                dogInView = (LayerMask.LayerToName(hit.transform.gameObject.layer) == "Animal");
            }
            else if (tag == "Human")
            {
                humanInView = (LayerMask.LayerToName(hit.transform.gameObject.layer) == "Human");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Animal" && detectOnlyHuman) return;

        if (other.tag == "Human")
        {
            humanDetected = true;
        }
        else if (other.tag == "Animal")
        {
            dogDetected = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Animal" && detectOnlyHuman) return;

        if (other.tag == "Human")
        {
            humanDetected = false;
            humanInView = false;
        }
        else if (other.tag == "Animal")
        {
            dogDetected = false;
            dogInView = false;
        }
    }

    void FixedUpdate()
    {
        if (humanDetected)
        {
            inFov(Human, "Human");
        }
        
        if (dogDetected)
        {
            inFov(Dog, "Animal");
        }
        handleAlarm();
    }

    void handleAlarm()
    {
        if (dogInView || humanInView)
        {
            inView = true;
            GetComponent<Light>().color = Color.red;
        }
        else
        {
            inView = false;
            GetComponent<Light>().color = Color.white;
        }
    }
}
