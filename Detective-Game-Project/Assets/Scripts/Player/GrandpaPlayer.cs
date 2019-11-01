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
            
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
            rotation *= Time.deltaTime;
            transform.Rotate(0, rotation, 0);
        }
    }

    private void FixedUpdate()
    {
        if (is_active_player)
        {
            float translation = Input.GetAxis("Vertical") * speed;
            translation *= Time.deltaTime;
            Vector3 newPosition = transform.position + transform.forward * translation;

            GetComponent<Rigidbody>().MovePosition(newPosition);
        }
    }
}
