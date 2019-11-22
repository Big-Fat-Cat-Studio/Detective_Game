using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRespawn : MonoBehaviour
{
    public GameObject DemoCrate1, DemoCrate2;
    Vector3 startPos;
    bool respawn = false;

    void Start()
    {
        startPos = DemoCrate1.transform.position;
    }


    void Update()
    {
        if (respawn == false && DemoCrate1.transform.position.y < gameObject.transform.position.y && DemoCrate2.transform.position.y < gameObject.transform.position.y)
        {
            respawn = true;
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut()
    {
        // fadeout code
        yield return new WaitForSecondsRealtime(2);
        DemoCrate1.transform.position = startPos;
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        // fadein code
        yield return new WaitForSecondsRealtime(2);
        respawn = false;
    }
}
