using System.Collections;
using Cinemachine;
using UnityEngine;

namespace Scripts
{
    public class Tunnel : MonoBehaviour
    {
        public GameObject TunnelA, TunnelB, Camera, ClueCamera;
        Vector3 moveInRot, moveOutRot, moveInDir, moveOutDir;
        bool Crawling = false;
        public enum FacingTunnelA {Front, Right, Back, Left};
        public enum FacingTunnelB {Front, Right, Back, Left};
        public FacingTunnelA facingTunnelA;
        public FacingTunnelB facingTunnelB;

        public GameObject CinCamera;
        private CinemachineFreeLook CinCameraConxtext;

        void Start()
        {
            CinCameraConxtext = CinCamera.GetComponent<CinemachineFreeLook>();


            //Currently not used, might come in handy later - Martin

            // if (facingTunnelA == FacingTunnelA.Right)
            // {
            //     moveInRot = new Vector3(75, 0, 0);
            //     moveInDir = new Vector3(-2, 1.5f, 0);
            // }
            // else if (facingTunnelA == FacingTunnelA.Front)
            // {
            //     moveInRot = new Vector3(0, 0, 75);
            //     moveInDir = new Vector3(0, 1.5f, -2);
            // }
            // else if (facingTunnelA == FacingTunnelA.Left)
            // {
            //     moveInRot = new Vector3(-75, 0, 0);
            //     moveInDir = new Vector3(2, 1.5f, 0);
            // }
            // else if (facingTunnelA == FacingTunnelA.Back)
            // {
            //     moveInRot = new Vector3(0, 0, -75);
            //     moveInDir = new Vector3(0, 1.5f, 2);
            // }
            //
            //
            // if (facingTunnelB == FacingTunnelB.Right)
            // {
            //     moveOutRot = new Vector3(0, 270, 0);
            //     moveOutDir = new Vector3(-2, 0, 0);
            // }
            // else if (facingTunnelB == FacingTunnelB.Front)
            // {
            //     moveOutRot = new Vector3(0, 180, 0);
            //     moveOutDir = new Vector3(0, 0, -2);
            // }
            // else if (facingTunnelB == FacingTunnelB.Left)
            // {
            //     moveOutRot = new Vector3(0, 90, 0);
            //     moveOutDir = new Vector3(2, 0, 0);
            // }
            // else if (facingTunnelB == FacingTunnelB.Back)
            // {
            //     moveOutRot = new Vector3(0, 0, 0);
            //     moveOutDir = new Vector3(0, 0, 2);
            // }
        }


        void OnTriggerEnter(Collider collision)
        {
            if (ReferenceEquals(collision.gameObject, GameManager.Instance.Animal))
            {
                TunnelA.GetComponent<BoxCollider>().enabled = true;
                TunnelB.GetComponent<BoxCollider>().enabled = false;
                GameManager.Instance.Animal.GetComponent<CharacterController>().enabled = false;
                StartCoroutine(MoveIn());
            }
        }


        IEnumerator MoveIn()
        {
            yield return new WaitForSecondsRealtime(2);
            if (ReferenceEquals(gameObject, TunnelA))
            {
                GameManager.Instance.Animal.transform.position = TunnelB.transform.position;
            }
            if (ReferenceEquals(gameObject, TunnelB))
            {
                GameManager.Instance.Animal.transform.position = TunnelA.transform.position;
            }
            StartCoroutine(MoveOut());
        }


        IEnumerator MoveOut()
        {
            GameManager.Instance.Animal.GetComponent<CharacterController>().enabled = true;
            yield return new WaitForSecondsRealtime(2f);
            TunnelA.GetComponent<BoxCollider>().enabled = true;
            TunnelB.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
