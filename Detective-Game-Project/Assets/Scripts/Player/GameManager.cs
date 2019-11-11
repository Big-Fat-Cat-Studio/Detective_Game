using UnityEngine;
using Cinemachine;

namespace Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        public GameObject Grandpa;
        public GameObject Kid;

        [HideInInspector]
        public ActivePlayer ActivePlayer;

        [Header("Not for the actual cameras, place the \"FreeLookN\" objects here.\n")]
        public GameObject CameraContext;
        public GameObject CameraContextClue;

        private float _PrevPlayerORotation; // Object X-Axis Rotation
        private float _PrevPlayerCRotation; // Camera X-Axis Rotation
        private void Start()
        {
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

                if (ActivePlayer == ActivePlayer.Grandpa)
                {
                    Grandpa.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
                    Kid.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);

                    cameraContext.Follow = Kid.transform;
                    cameraContext.LookAt = Kid.transform;
                    ActivePlayer = ActivePlayer.Kid;
                }
                else if (ActivePlayer == ActivePlayer.Kid)
                {
                    Kid.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
                    Grandpa.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);

                    cameraContext.Follow = Grandpa.transform;
                    cameraContext.LookAt = Grandpa.transform;
                    ActivePlayer = ActivePlayer.Grandpa;
                }

                var tempX = cameraContext.m_XAxis.Value;
                cameraContext.m_XAxis.Value = _PrevPlayerCRotation;
                _PrevPlayerCRotation = tempX;
            }
        }
    }
}