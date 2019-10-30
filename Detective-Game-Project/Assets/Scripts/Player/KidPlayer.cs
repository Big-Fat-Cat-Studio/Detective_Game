using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidPlayer : MonoBehaviour
{
    public bool is_active_player;

    // Update is called once per frame
    void Update()
    {
        if(this.is_active_player)
        {
            print("kid is active");
        }
    }
}
