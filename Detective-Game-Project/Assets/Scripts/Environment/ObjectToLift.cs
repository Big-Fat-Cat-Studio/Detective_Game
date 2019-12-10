using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class ObjectToLift : MonoBehaviour
    {
        public Direction direction;
        public float amountOfMovement;
        public float speed;
        public bool moveAutomatically = false;

        private List<GameObject> objectsOnPlatform;
        private float originalPosition;
        private Rigidbody rigidBody;
        private bool move = false;

        // Start is called before the first frame update
        void Start()
        {
            if (direction == Direction.XMinus || direction == Direction.XPlus)
            {
                originalPosition = transform.position.x;
            }
            else if (direction == Direction.YMinus || direction == Direction.YPlus)
            {
                originalPosition = transform.position.y;
            }
            else
            {
                originalPosition = transform.position.z;
            }
            objectsOnPlatform = new List<GameObject>();
            rigidBody = GetComponent<Rigidbody>();

            if (moveAutomatically)
            {
                startMoving();
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (move)
            {
                if (direction == Direction.XMinus)
                {
                    rigidBody.gameObject.transform.Translate(Vector3.left * Time.deltaTime * speed);

                    if (transform.position.x < originalPosition - amountOfMovement)
                    {
                        move = false;
                    }
                }
                else if (direction == Direction.XPlus)
                {
                    rigidBody.gameObject.transform.Translate(Vector3.right * Time.deltaTime * speed);
                    if (transform.position.x > originalPosition + amountOfMovement)
                    {
                        move = false;
                    }
                }
                else if (direction == Direction.YMinus)
                {
                    rigidBody.gameObject.transform.Translate(Vector3.down * Time.deltaTime * speed);
                    if (transform.position.y < originalPosition - amountOfMovement)
                    {
                        move = false;
                    }
                }
                else if (direction == Direction.YPlus)
                {
                    rigidBody.gameObject.transform.Translate(Vector3.up * Time.deltaTime * speed);
                    if (transform.position.y > originalPosition + amountOfMovement)
                    {
                        move = false;
                    }
                }
                else if (direction == Direction.ZMinus)
                {
                    rigidBody.gameObject.transform.Translate(Vector3.back * Time.deltaTime * speed);
                    if (transform.position.z < originalPosition - amountOfMovement)
                    {
                        move = false;
                    }
                }
                else if (direction == Direction.ZPlus)
                {
                    rigidBody.gameObject.transform.Translate(Vector3.forward * Time.deltaTime * speed);
                    if (transform.position.z > originalPosition + amountOfMovement)
                    {
                        move = false;
                    }
                }

                if (!move && moveAutomatically)
                {
                    startMoving();
                }
            }
        }

        public void startMoving()
        {
            if (!move)
            {
                move = true;

                if (direction == Direction.XMinus && transform.position.x < originalPosition - amountOfMovement)
                {
                    originalPosition = transform.position.x;
                    direction = Direction.XPlus;
                }
                else if (direction == Direction.XPlus && transform.position.x > originalPosition + amountOfMovement)
                {
                    originalPosition = transform.position.x;
                    direction = Direction.XMinus;
                }
                else if (direction == Direction.YMinus && transform.position.y < originalPosition - amountOfMovement)
                {
                    originalPosition = transform.position.y;
                    direction = Direction.YPlus;
                }
                else if (direction == Direction.YPlus && transform.position.y > originalPosition + amountOfMovement)
                {
                    originalPosition = transform.position.y;
                    direction = Direction.YMinus;
                }
                else if (direction == Direction.ZMinus && transform.position.z < originalPosition - amountOfMovement)
                {
                    originalPosition = transform.position.z;
                    direction = Direction.ZPlus;
                }
                else if (direction == Direction.ZPlus && transform.position.z > originalPosition + amountOfMovement)
                {
                    originalPosition = transform.position.z;
                    direction = Direction.ZMinus;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (ReferenceEquals(other.gameObject, GameManager.Instance.Human) ||
                ReferenceEquals(other.gameObject, GameManager.Instance.Animal))
            {
                other.gameObject.transform.parent = this.gameObject.transform;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (ReferenceEquals(other.gameObject, GameManager.Instance.Human) ||
                ReferenceEquals(other.gameObject, GameManager.Instance.Animal))
            {
                other.gameObject.transform.parent = null;

            }
        }
    }
}