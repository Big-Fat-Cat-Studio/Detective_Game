using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewDetection : MonoBehaviour
{
    public bool detectOnlyHuman;

    public Transform Human;
    public bool humanDetected, humanInView;

    public Transform Dog;
    public bool dogDetected, dogInView;

    public bool inView;
    private bool disabled;

    void OnEnable()
    {
        if (!disabled) return;

        Collider collider = transform.GetChild(0).transform.gameObject.GetComponent<MeshCollider>();

        humanDetected = humanInView = collider.bounds.Contains(Human.position);
        dogDetected = dogInView = collider.bounds.Contains(Dog.position);

        disabled = false;
    }

    void OnDisable()
    {
        disabled = true;
    }

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

    public void OnChildTriggerEnter(Collider other)
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

    public void OnChildTriggerExit(Collider other)
    {
        if (other.tag == "Animal" && detectOnlyHuman) return;

        if (other.tag == "Human")
        {
            humanDetected = humanInView = false;
        }
        else if (other.tag == "Animal")
        {
            dogDetected = dogInView = false;
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
