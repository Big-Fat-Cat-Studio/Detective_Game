using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidPlayer : MonoBehaviour
{
    public float speed = 5.0f;
    public float climbing_speed = 0.1f;
    public float rotationSpeed = 100.0f;
    public bool is_active_player;
    public bool is_climbing = false;

    // Update is called once per frame
    void Update()
    {
        if(this.is_active_player)
        {
            print("kid is active");
            if(is_climbing)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    this.gameObject.transform.Translate(Vector3.up * climbing_speed);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    this.gameObject.transform.Translate(Vector3.down * climbing_speed);
                }
                else
                {
                    this.gameObject.transform.Translate(new Vector3(0, 0, 0));
                }
            }
            if(!is_climbing)
            {
                float translation = Input.GetAxis("Vertical") * speed;
                float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
                translation *= Time.deltaTime;
                rotation *= Time.deltaTime;
                transform.Translate(0, 0, translation);
                transform.Rotate(0, rotation, 0);
            }
        }
    }
}