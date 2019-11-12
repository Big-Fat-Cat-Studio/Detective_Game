using UnityEngine;
using Cinemachine;

namespace Scripts
{
    public class HumanPlayer : MonoBehaviour
    {
        public float speed = 2.0f;
        public float rotationSpeed = 100.0f;
        Rigidbody rigidBody;

        private CinemachineFreeLook context;

        private void Start()
        {
            rigidBody = GetComponent<Rigidbody>();
            context = GameManager.Instance.CameraContext.GetComponent<CinemachineFreeLook>();
            Cursor.visible = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance.ActivePlayer == ActivePlayer.Human)
            {
                float translationRH = Input.GetAxisRaw("Mouse X") * rotationSpeed;
                translationRH *= Time.deltaTime;
                context.m_XAxis.Value += translationRH;

                transform.Rotate(0, translationRH, 0);
            }
        }

        private void FixedUpdate()
        {
            if (GameManager.Instance.ActivePlayer == ActivePlayer.Human)
            {
                float translation = Input.GetAxis("Vertical") * speed;
                rigidBody.velocity =
                    new Vector3(transform.forward.x * translation, rigidBody.velocity.y, transform.forward.z * translation);
            }
        }
    }
}