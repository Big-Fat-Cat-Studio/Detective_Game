using UnityEngine;
using Cinemachine;

namespace Scripts
{
    public class SwitchPlayer : MonoBehaviour
    {
        public GameObject Grandpa;
        public GameObject Kid;
        public static ActivePlayer ActivePlayer;

        [Header("Not for the actual cameras, place the \"FreeLookN\" objects here.\n")]
        public GameObject CameraContext;
        public GameObject CameraContextClue;

        private float _PrevPlayerORotation; // Object X-Axis Rotation
        private float _PrevPlayerCRotation; // Camera X-Axis Rotation
        private void Start()
        {

            Grandpa.GetComponent<GrandpaPlayer>().is_active_player = true;
            Grandpa.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);

            ActivePlayer = ActivePlayer.Grandpa;
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                CinemachineFreeLook cameraContext = CameraContext.GetComponent<CinemachineFreeLook>();
                CinemachineFreeLook cameraContextClue = CameraContextClue.GetComponent<CinemachineFreeLook>();

                if (SwitchPlayer.ActivePlayer == ActivePlayer.Grandpa)
                {
                    Grandpa.GetComponent<GrandpaPlayer>().is_active_player = false;
                    Grandpa.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
                    Kid.GetComponent<KidPlayer>().is_active_player = true;
                    Kid.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);


                    cameraContext.Follow = Kid.transform;
                    cameraContext.LookAt = Kid.transform;
                    SwitchPlayer.ActivePlayer = ActivePlayer.Kid;

                    var tempX = cameraContext.m_XAxis.Value;
                    cameraContext.m_XAxis.Value = _PrevPlayerCRotation;
                    _PrevPlayerCRotation = tempX;
                }
                else if (SwitchPlayer.ActivePlayer == ActivePlayer.Kid)
                {
                    Kid.GetComponent<KidPlayer>().is_active_player = false;
                    Kid.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
                    Grandpa.GetComponent<GrandpaPlayer>().is_active_player = true;
                    Grandpa.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
                    cameraContext.Follow = Grandpa.transform;
                    cameraContext.LookAt = Grandpa.transform;
                    SwitchPlayer.ActivePlayer = ActivePlayer.Grandpa;

                    var tempX = cameraContext.m_XAxis.Value;
                    cameraContext.m_XAxis.Value = _PrevPlayerCRotation;
                    _PrevPlayerCRotation = tempX;
                }
            }
        }
    }
}