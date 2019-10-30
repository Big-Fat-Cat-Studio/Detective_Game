using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandpaPlayer : MonoBehaviour
{
    public bool is_active_player;

    // Update is called once per frame
    void Update()
    {
        if(is_active_player)
        {
            print("grandpa is active");
        }
    }
}
