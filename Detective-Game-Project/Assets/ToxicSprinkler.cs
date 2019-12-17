using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicSprinkler : MonoBehaviour
{
    public ParticleSystem water;

    public void Disable()
    {
        this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        water.Stop();
    }
}
