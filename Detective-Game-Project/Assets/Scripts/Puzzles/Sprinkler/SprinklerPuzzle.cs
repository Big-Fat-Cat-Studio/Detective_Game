using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts
{
    public class SprinklerPuzzle : InteractableObject
    {
        // ElEMENTS / IMAGES NEED TO BE ADDED IN FOLLOWING ORDER: 4, 3, 5, 1, 2
        public GameObject victoryInteraction;
        public GameObject puzzleCamera;
        public GameObject indicator;
        public GameObject[] elementArray;
        public GameObject selector;
        public GameObject[] imageArray;
        public AudioClip waterpressuresolved;
        Vector3[] positionArray = new[]
        {
            new Vector3 (4.5f, 0, -1),
            new Vector3 (6.25f, 0, 1),
            new Vector3 (7, 0, -2),
            new Vector3 (7.25f, 0, 3),
            new Vector3 (8.25f, 0, 1.25f)
        };

        bool[] active = {true, true, true, true, true};
        bool[] placed = {true, true, true, true, true};

        int select = 0;
        int point = 0;
        int elements = 5;
        int max;
        float yOffset = 0.39f;
        float xOffset = 0.81f;

        [HideInInspector]
        public int solved = 0;


        void Start()
        {
            max = elements - 1;
            // randomize stuff a bit
            imageArray[0].transform.Rotate(0, 0, 90);
            imageArray[1].transform.Rotate(0, 0, 90);
            imageArray[2].transform.Rotate(0, 0, 90);
            imageArray[3].transform.Rotate(0, 0, 180);
            imageArray[4].transform.Rotate(0, 0, 180);

            /*if (GameManager.Instance.GameType == GameType.SinglePlayer)
            {
                puzzleCamera.GetComponent<Camera>().rect = new Rect (0, 0, 1, 1);
            }
            else if (GameManager.Instance.GameType == GameType.MultiPlayerSplitScreen)
            {
                puzzleCamera.GetComponent<Camera>().rect = new Rect (0, 0.5f, 1, 1);
            }*/
        }

        public override void interact(ActivePlayer player)
        {
            if (!puzzleCamera.activeSelf)
            {
                puzzleCamera.SetActive(true);
                indicator.SetActive(true);
                GameManager.Instance.Human.GetComponent<HumanPlayer>().isInPuzzle = true;
                InputType type = GameManager.Instance.Human.GetComponent<HumanPlayer>().inputType;


                if (type == InputType.Controller)
                {
                    GetComponent<PlayerInput>().SwitchCurrentControlScheme(type.ToString(), Gamepad.all[0]);
                }
                else
                {
                    GetComponent<PlayerInput>().SwitchCurrentControlScheme(type.ToString(), Mouse.current, Keyboard.current);
                }

                interactable = false;
            }
        }


        void Update()
        {
            if (selector.transform.position == new Vector3(937.5f, -270, 0))
            {
                selector.transform.position = imageArray[0].transform.position;
            }

            if (solved == 5)
            {
                Finished();
            }
        }


        void MovePipeDown()
        {
            if (point < max)
            {
                Vector3 position = indicator.transform.localPosition;
                int check = point;
                bool done = false;
                while (done == false)
                {
                    check++;
                    if (placed[check] == true)
                    {
                        done = true;
                    }
                    else if (check == max)
                    {
                        check = point;
                        done = true;
                    }
                }
                point = check;
                position = positionArray[point];
                indicator.transform.localPosition = position;
            }
        }


        void MovePipeUp()
        {
            if (point > 0)
            {
                Vector3 position = indicator.transform.localPosition;
                int check = point;
                bool done = false;
                while (done == false)
                {
                    check--;
                    if (placed[check] == true)
                    {
                        done = true;
                    }
                    else if (check == 0)
                    {
                        check = point;
                        done = true;
                    }
                }
                point = check;
                position = positionArray[point];
                indicator.transform.localPosition = position;
            }
        }


        void SelectRight()
        {
            if (select < max)
            {
                int check = select;
                bool done = false;
                while (done == false)
                {
                    check++;
                    if (active[check] == true)
                    {
                        done = true;
                    }
                    else if (check == max)
                    {
                        check = select;
                        done = true;
                    }
                }
                selector.transform.position = imageArray[check].transform.position;
                select = check;
            }
        }


        void SelectLeft()
        {
            if (select > 0)
            {
                int check = select;
                bool done = false;
                while (done == false)
                {
                    check--;
                    if (active[check] == true)
                    {
                        done = true;
                    }
                    else if (check == 0)
                    {
                        check = select;
                        done = true;
                    }
                }
                selector.transform.position = imageArray[check].transform.position;
                select = check;
            }
        }


        void Progress()
        {
            imageArray[select].gameObject.SetActive(false);
            active[select] = false;
            placed[point] = false;
            solved += 1;
            int check = select;
            MovePipeDown();
            if (check == select)
            {
                MovePipeUp();
            }
            check = point;
            SelectRight();
            if (check == point)
            {
                SelectLeft();
            }
        }


        void Finished()
        {
            gameObject.GetComponent<AudioSource>().clip = waterpressuresolved;
            gameObject.GetComponent<AudioSource>().Play();
            puzzleCamera.SetActive(false);
            indicator.SetActive(false);
            GameManager.Instance.Human.GetComponent<HumanPlayer>().isInPuzzle = false;
            interactable = true;
            if (solved == 5)
            {
                victoryInteraction.GetComponent<IPuzzleResult>().ActivateSolution();
                Destroy(this);
            }
        }

        private void OnUp()
        {
            MovePipeUp();
        }

        private void OnDown()
        {
            MovePipeDown();
        }

        private void OnLeft()
        {
            SelectLeft();
        }

        private void OnRight()
        {
            SelectRight();
        }

        private void OnRotateLeft()
        {
            imageArray[select].transform.Rotate(0, 0, 90);
        }

        private void OnRotateRight()
        {
            imageArray[select].transform.Rotate(0, 0, -90);
        }

        private void OnPlace()
        {
            float eulerAngZ = imageArray[select].transform.localEulerAngles.z;
            if (select == 0 && point == 3) // element 4
            {
                if (eulerAngZ == 180)
                {
                    elementArray[select].transform.localRotation = Quaternion.Euler(270, 0, 0);
                    elementArray[select].transform.localPosition = new Vector3(7.25f, 0, 3);
                    Progress();
                }
            }
            if (select == 1 && point == 1) // element 3
            {
                if (eulerAngZ == 0 || eulerAngZ == 180)
                {
                    elementArray[select].transform.localRotation = Quaternion.Euler(0, 0, 0);
                    elementArray[select].transform.localPosition = new Vector3(17.0625f, 0, 0.75f);
                    Progress();
                }
            }
            if (select == 2 && point == 4) // element 5
            {
                if (eulerAngZ == 0)
                {
                    elementArray[select].transform.localRotation = Quaternion.Euler(0, 0, 0);
                    elementArray[select].transform.localPosition = new Vector3(8.25f, 0, 1.5f);
                    Progress();
                }
            }
            if (select == 3 && point == 0) // element 1
            {
                if (eulerAngZ <= 1 || eulerAngZ == 180)
                {
                    elementArray[select].transform.localRotation = Quaternion.Euler(0, 0, 0);
                    elementArray[select].transform.localPosition = new Vector3(4.5f, 0, 0);
                    Progress();
                }
            }
            if (select == 4 && point == 2) // element 2
            {
                if (eulerAngZ <= 1)
                {
                    elementArray[select].transform.localRotation = Quaternion.Euler(0, 0, 0);
                    elementArray[select].transform.localPosition = new Vector3(5.75f, 0, -1);
                    Progress();
                }
            }
        }

        private void OnExit()
        {
            Finished();
        }
    }

}
