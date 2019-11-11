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
                GameManager.Instance.Kid.transform.Rotate(moveInRot * (Time.deltaTime * 1.5f));
            }
        }


        void OnCollisionEnter(Collision collision)
        {
            if (ReferenceEquals(collision.gameObject, GameManager.Instance.Kid))
            {
                GameManager.Instance.Kid.GetComponent<CapsuleCollider>().enabled = false;
                GameManager.Instance.Kid.GetComponent<KidPlayer>().enabled = false;
                Camera.GetComponent<Camera>().target = null;
                ClueCamera.GetComponent<Camera>().target = null;
                GameManager.Instance.Kid.GetComponent<Rigidbody>().velocity = moveInDir;
                GameManager.Instance.Kid.GetComponent<Rigidbody>().useGravity = false;
                Crawling = true;
                StartCoroutine(MoveIn());
            }
        }


        IEnumerator MoveIn()
        {
            yield return new WaitForSecondsRealtime(0.75f);
            Crawling = false;
            GameManager.Instance.Kid.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            StartCoroutine(Delay());
        }


        IEnumerator Delay()
        {
            yield return new WaitForSecondsRealtime(2);
            if (ReferenceEquals(gameObject, TunnelA))
            {
                GameManager.Instance.Kid.transform.position = TunnelB.transform.position;

            }
            if (ReferenceEquals(gameObject, TunnelB))
            {
                GameManager.Instance.Kid.transform.position = TunnelA.transform.position;
            }

            if (Camera.GetComponent<Camera>().target == null)
            {
                Camera.GetComponent<Camera>().target = GameManager.Instance.Kid.transform;
                ClueCamera.GetComponent<Camera>().target = GameManager.Instance.Kid.transform;
            }

            //TODO(Hamza): Pass just the pitch rotation, others cause the camera to bug out.
            // Make it so the camera follows the player's forward vector regardless of the
            // previous X-axis.

            CinCameraConxtext.m_XAxis.Value = -90;
            GameManager.Instance.Kid.transform.rotation = Quaternion.Euler(moveOutRot);
            GameManager.Instance.Kid.GetComponent<Rigidbody>().velocity = moveOutDir;
            StartCoroutine(MoveOut());
        }


        IEnumerator MoveOut()
        {
            yield return new WaitForSecondsRealtime(0.5f);
            GameManager.Instance.Kid.GetComponent<Rigidbody>().useGravity = true;
            GameManager.Instance.Kid.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            GameManager.Instance.Kid.GetComponent<CapsuleCollider>().enabled = true;
            GameManager.Instance.Kid.GetComponent<KidPlayer>().enabled = true;
        }
    }
}
