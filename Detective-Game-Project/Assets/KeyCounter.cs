using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;

public class KeyCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Key TestObject = Object.FindObjectOfType<Key>();
        Debug.Log(TestObject.amountNeeded);
    }
}
