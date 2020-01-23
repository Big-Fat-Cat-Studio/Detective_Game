using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    Quaternion guardOG;
    float lookbackin;
    // Start is called before the first frame update
    void Start()
    {
        guardOG = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        lookbackin -= Time.deltaTime;

        

        if (transform.rotation != guardOG)
        {
            if (lookbackin < -1)
            {
                lookbackin = 5f;
            }
            
        }
        
        if (lookbackin < 0 && transform.rotation != guardOG)
        {
            gameObject.transform.rotation = guardOG;
        }

    }
}
