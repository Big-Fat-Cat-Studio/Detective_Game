using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Tunnel : MonoBehaviour
    {
        public GameObject Kid, TunnelA, TunnelB, TunnelWall;


        void Start()
        {
            
        }


        void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.name == "Kid")
            {
                //disable colliders
                TunnelA.GetComponent<CapsuleCollider>().enabled = false;
                TunnelB.GetComponent<CapsuleCollider>().enabled = false;
                TunnelWall.GetComponent<BoxCollider>().enabled = false;
                //disable movement script
                Kid.GetComponent<Player>().enabled = false;
                Kid.GetComponent<Rigidbody>().velocity = new Vector3(-5, 0, 0);
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
            if (this.gameObject.name == "Tunnel A")
            {
                Kid.transform.position = TunnelB.transform.position;

            }
            if (this.gameObject.name == "Tunnel B")
            {
                Kid.transform.position = TunnelA.transform.position;
            }
            //probably needs to be changed so player turns 180 degrees and doesn't walk backwards.
            Kid.transform.Rotate(new Vector3(0, 180, 0));
            Kid.GetComponent<Rigidbody>().velocity = new Vector3(5, 0, 0);
            StartCoroutine(MoveOut());
        }


        IEnumerator MoveOut()
        {
            yield return new WaitForSecondsRealtime(1f);
            Kid.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            TunnelA.GetComponent<CapsuleCollider>().enabled = true;
            TunnelB.GetComponent<CapsuleCollider>().enabled = true;
            TunnelWall.GetComponent<BoxCollider>().enabled = true;
            Kid.GetComponent<Player>().enabled = true;
        }
    }
}
