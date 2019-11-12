using UnityEngine;
using Cinemachine;

namespace Scripts
{
    public class GameManager : MonoBehaviour
    {

        //Singleton, so we can access human/animal everywhere
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

        public GameObject Human;
        public GameObject Animal;

        [HideInInspector]
        public ActivePlayer ActivePlayer;

        [Header("Not for the actual cameras, place the \"FreeLookN\" objects here.\n")]
        public GameObject CameraContext;
        public GameObject CameraContextClue;

        private float _PrevPlayerORotation; // Object X-Axis Rotation
        private float _PrevPlayerCRotation; // Camera X-Axis Rotation
        private void Start()
        {
            Human.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
            ActivePlayer = ActivePlayer.Human;
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                CinemachineFreeLook cameraContext = CameraContext.GetComponent<CinemachineFreeLook>();
                CinemachineFreeLook cameraContextClue = CameraContextClue.GetComponent<CinemachineFreeLook>();

                if (ActivePlayer == ActivePlayer.Human)
                {
                    Human.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
                    Animal.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);

                    cameraContext.Follow = Animal.transform;
                    cameraContext.LookAt = Animal.transform;
                    ActivePlayer = ActivePlayer.Animal;
                }
                else if (ActivePlayer == ActivePlayer.Animal)
                {
                    Animal.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
                    Human.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);

                    cameraContext.Follow = Human.transform;
                    cameraContext.LookAt = Human.transform;
                    ActivePlayer = ActivePlayer.Human;
                }

                var tempX = cameraContext.m_XAxis.Value;
                cameraContext.m_XAxis.Value = _PrevPlayerCRotation;
                _PrevPlayerCRotation = tempX;
            }
        }
    }
}