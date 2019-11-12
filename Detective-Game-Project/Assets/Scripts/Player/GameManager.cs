using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using System.Collections;

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
        [HideInInspector]
        public ActivePlayer? InteractTextActivePlayer;
        [HideInInspector]
        public ActivePlayer? PickupTextActivePlayer;

        [Header("Put the text game objects here")]
        public GameObject AfterInteractText;
        public GameObject InteractText;
        public GameObject PickupText;

        private IEnumerator currentCourotine;

        [Header("Not for the actual cameras, place the \"FreeLookN\" objects here.\n")]
        public GameObject CameraContext;
        //public GameObject CameraContextClue;

        private float _PrevPlayerORotation; // Object X-Axis Rotation
        private float _PrevPlayerCRotation; // Camera X-Axis Rotation
        private void Start()
        {
            Human.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
            ActivePlayer = ActivePlayer.Human;
            AfterInteractText.SetActive(false);
            InteractText.SetActive(false);
            PickupText.SetActive(false);
            currentCourotine = null;
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                CinemachineFreeLook cameraContext = CameraContext.GetComponent<CinemachineFreeLook>();
                //CinemachineFreeLook cameraContextClue = CameraContextClue.GetComponent<CinemachineFreeLook>();

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

        public void removeInteractText(ActivePlayer player)
        {
            if (InteractTextActivePlayer == player)
            {
                InteractText.SetActive(false);
                InteractTextActivePlayer = null;
            }
        }

        public void removePickupText(ActivePlayer player)
        {
            if (PickupTextActivePlayer == player)
            {
                PickupText.SetActive(false);
                PickupTextActivePlayer = null;
            }
        }

        public void showInteractText(string message, ActivePlayer player)
        {
            InteractText.GetComponent<Text>().text = Constant.INTERACT_TEXT + message;
            InteractText.SetActive(true);
            InteractTextActivePlayer = player;
        }

        public void showPickupText(string message, ActivePlayer player)
        {
            PickupText.GetComponent<Text>().text = Constant.PICKUP_TEXT + message;
            PickupText.SetActive(true);
            PickupTextActivePlayer = player;
        }

        public void showAfterInteractText(string message)
        {
            AfterInteractText.GetComponent<Text>().text = message;
            AfterInteractText.SetActive(true);
            if (currentCourotine != null)
            {
                StopCoroutine(currentCourotine);
            }

            currentCourotine = afterInteractTextDisappear();
            StartCoroutine(currentCourotine);
        }

        IEnumerator afterInteractTextDisappear()
        {
            yield return new WaitForSecondsRealtime(6);
            AfterInteractText.SetActive(false);
            currentCourotine = null;
        }
    }
}