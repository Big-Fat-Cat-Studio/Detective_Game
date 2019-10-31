using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandpaPlayer : MonoBehaviour
{
    public float speed = 2.0f;
    public float rotationSpeed = 100.0f;
    public bool is_active_player;

    // Update is called once per frame
    void Update()
    {
        if(is_active_player)
        {
            //print("grandpa is active");
            float translation = Input.GetAxis("Vertical") * speed;
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;
            transform.Translate(0, 0, translation);
            transform.Rotate(0, rotation, 0);
        }
    }
}
