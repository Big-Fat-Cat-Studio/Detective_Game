using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Tunnel : MonoBehaviour
    {
        public GameObject Kid, TunnelA, TunnelB, TunnelWall, Camera;

        void Start()
        {
            
        }


        void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.name == "Kid")
            {
                Kid.GetComponent<CapsuleCollider>().enabled = false;
                Kid.GetComponent<KidPlayer>().enabled = false;
                Camera.GetComponent<Camera>().target = null;
                Kid.GetComponent<Rigidbody>().velocity = new Vector3(-2, 0, 0);
                Kid.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                Kid.GetComponent<Rigidbody>().useGravity = false;
                StartCoroutine(MoveIn());
            }
        }


        IEnumerator MoveIn()
        {
            yield return new WaitForSecondsRealtime(0.75f);
            Kid.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            StartCoroutine(Delay());
        }


        IEnumerator Delay()
        {
            yield return new WaitForSecondsRealtime(2);
            if (ReferenceEquals(gameObject, TunnelA))
            {
                Kid.transform.position = TunnelB.transform.position;

            }
            if (ReferenceEquals(gameObject, TunnelB))
            {
                Kid.transform.position = TunnelA.transform.position;
            }

            Kid.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            if (Camera.GetComponent<Camera>().target == null)
            {
                Camera.GetComponent<Camera>().target = Kid.transform; 
            }

            
            Kid.transform.Rotate(new Vector3(0, 180, 0));
            Kid.GetComponent<Rigidbody>().velocity = new Vector3(2, 0, 0);
            StartCoroutine(MoveOut());
        }


        IEnumerator MoveOut()
        {
            yield return new WaitForSecondsRealtime(0.5f);
            Kid.GetComponent<Rigidbody>().useGravity = true;
            Kid.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            Kid.GetComponent<CapsuleCollider>().enabled = true;
            Kid.GetComponent<KidPlayer>().enabled = true;
        }
    }
}
