using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bark : MonoBehaviour
{

    void Start()
    {
        ParticleSystem particle = GetComponent<ParticleSystem>();
        Destroy(gameObject, particle.duration + particle.startLifetime);
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.name.ToLower().Contains("guard"))
        {
            Debug.Log("Dog detected at: " + transform.position);
        }
    }
}
