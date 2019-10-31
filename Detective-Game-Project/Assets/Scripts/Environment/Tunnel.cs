using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Tunnel : MonoBehaviour
    {
        public GameObject Kid, TunnelA, TunnelB, Camera;
        Vector3 moveInRot, moveOutRot, moveInDir, moveOutDir;
        bool Crawling = false;
        public enum FacingTunnelA {Front, Right, Back, Left};
        public enum FacingTunnelB {Front, Right, Back, Left};
        public FacingTunnelA facingTunnelA;
        public FacingTunnelB facingTunnelB;

        void Start()
        {
            if (facingTunnelA == FacingTunnelA.Right)
            {
                moveInRot = new Vector3(75, 0, 0);
                moveInDir = new Vector3(-2, 1.5f, 0);
            }
            else if (facingTunnelA == FacingTunnelA.Front)
            {
                moveInRot = new Vector3(0, 0, 75);
                moveInDir = new Vector3(0, 1.5f, -2);
            }
            else if (facingTunnelA == FacingTunnelA.Left)
            {
                moveInRot = new Vector3(-75, 0, 0);
                moveInDir = new Vector3(2, 1.5f, 0);
            }
            else if (facingTunnelA == FacingTunnelA.Back)
            {
                moveInRot = new Vector3(0, 0, -75);
                moveInDir = new Vector3(0, 1.5f, 2);
            }


            if (facingTunnelB == FacingTunnelB.Right)
            {
                moveOutRot = new Vector3(0, 270, 0);
                moveOutDir = new Vector3(-2, 0, 0);
            }
            else if (facingTunnelB == FacingTunnelB.Front)
            {
                moveOutRot = new Vector3(0, 180, 0);
                moveOutDir = new Vector3(0, 0, -2);
            }
            else if (facingTunnelB == FacingTunnelB.Left)
            {
                moveOutRot = new Vector3(0, 90, 0);
                moveOutDir = new Vector3(2, 0, 0);
            }
            else if (facingTunnelB == FacingTunnelB.Back)
            {
                moveOutRot = new Vector3(0, 0, 0);
                moveOutDir = new Vector3(0, 0, 2);
            }
        }


        void FixedUpdate()
        {
            StandToCrawl();
        }


        void StandToCrawl()
        {
            if (Crawling)
            {
                Kid.transform.Rotate(moveInRot * (Time.deltaTime * 1.5f));
            }
        }


        void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.name == "Kid")
            {
                Kid.GetComponent<CapsuleCollider>().enabled = false;
                Kid.GetComponent<KidPlayer>().enabled = false;
                Camera.GetComponent<Camera>().target = null;
                Kid.GetComponent<Rigidbody>().velocity = moveInDir;
                Kid.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                Kid.GetComponent<Rigidbody>().useGravity = false;
                Crawling = true;
                StartCoroutine(MoveIn());
            }
        }


        IEnumerator MoveIn()
        {
            yield return new WaitForSecondsRealtime(0.75f);
            Crawling = false;
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


            Kid.transform.rotation = Quaternion.Euler(moveOutRot);
            Kid.GetComponent<Rigidbody>().velocity = moveOutDir;
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
