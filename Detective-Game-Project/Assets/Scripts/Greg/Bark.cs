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
            Vector3 relativePos = transform.position - collider.transform.position + Vector3.up * 1.5f;

            // the second argument, upwards, defaults to Vector3.up
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            collider.gameObject.transform.rotation = rotation;
        }
    }
}
