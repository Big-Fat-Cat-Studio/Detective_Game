using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 2.0f;
    public float rotationSpeed = 100.0f;

    public float jumpForce;
    public float glide;

    void Update()
    {

        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        if (gameObject.GetComponent<Rigidbody>().velocity.y == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(0,jumpForce,0);
            }
        }
        else if (gameObject.GetComponent<Rigidbody>().velocity.y < 0)
        {
           if (Input.GetKey(KeyCode.Space))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Physics.gravity = new Vector3 (0, glide ,0));
            } 

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Physics.gravity = new Vector3 (0, -9.81f ,0));
        } 

        

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
    }
}