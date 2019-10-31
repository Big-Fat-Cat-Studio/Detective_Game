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

    public float jumpForce;
    public float glide;

    // Update is called once per frame
    void Update()
    {
        if(this.is_active_player)
        {
            //print("kid is active");
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

                if (gameObject.GetComponent<Rigidbody>().velocity.y == 0)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        gameObject.GetComponent<Rigidbody>().AddForce(0, jumpForce, 0);
                    }
                }
                else if (gameObject.GetComponent<Rigidbody>().velocity.y < 0)
                {
                    if (Input.GetKey(KeyCode.Space))
                    {
                        gameObject.GetComponent<Rigidbody>().AddForce(Physics.gravity = new Vector3(0, glide, 0));
                    }

                }
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    gameObject.GetComponent<Rigidbody>().AddForce(Physics.gravity = new Vector3(0, -9.81f, 0));
                }

                transform.Translate(0, 0, translation);
                transform.Rotate(0, rotation, 0);
            }
        }
    }
}