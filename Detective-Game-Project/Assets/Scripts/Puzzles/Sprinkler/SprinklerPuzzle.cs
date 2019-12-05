using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprinklerPuzzle : MonoBehaviour
{
    // ElEMENTS / IMAGES NEED TO BE ADDED IN FOLLOWING ORDER: 4, 3, 5, 1, 2
    public GameObject human;
    public GameObject puzzleCamera;
    public GameObject indicator;
    public GameObject[] elementArray;
    public GameObject selector;
    public GameObject[] imageArray;
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
    float yOffset = 0.46f;

    [HideInInspector]
    public int solved = 0;


    void Start()
    {
        max = elements - 1;
        // randomize stuff a bit
        imageArray[0].transform.Rotate(0, 0, 90);
        imageArray[1].transform.Rotate(0, 0, 0);
        imageArray[2].transform.Rotate(0, 0, 90);
        imageArray[3].transform.Rotate(0, 0, 90);
        imageArray[4].transform.Rotate(0, 0, 180);
    }


    void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "Human")
        {
            if (Input.GetKeyDown (KeyCode.X))
            {
                puzzleCamera.SetActive(true);
                indicator.SetActive(true);
                // human.GetComponent<CharacterController>().enabled = false;
            }
        }
    }


    void Update()
    {
        // Move pipe selector
        if (Input.GetKeyDown (KeyCode.S))
        {
            SelectDown();
        }
        if (Input.GetKeyDown (KeyCode.W))
        {
            SelectUp();
        }


        // Rotate selection
        if (Input.GetKeyDown (KeyCode.RightArrow))
        {
            imageArray[select].transform.Rotate(0, 0, -90);
        }
        if (Input.GetKeyDown (KeyCode.LeftArrow))
        {
            imageArray[select].transform.Rotate(0, 0, 90);
        }


        // Move indicator
        if (Input.GetKeyDown (KeyCode.D))
        {
            PointRight();
        }
        if (Input.GetKeyDown (KeyCode.A))
        {
            PointLeft();
        }


        // Check if correct
        if (Input.GetKeyDown (KeyCode.X))
        {
            float eulerAngZ = imageArray[select].transform.localEulerAngles.z;
            if (select == 0 && point == 3) // element 4
            {
                if (eulerAngZ == 180)
                {
                    elementArray[select].transform.rotation = Quaternion.Euler(180, 0, 0);
                    elementArray[select].transform.localPosition = new Vector3 (7.25f, 0, 3);
                    Progress();
                }
            }
            if (select == 1 && point == 1) // element 3
            {
                if (eulerAngZ == 0 || eulerAngZ == 180)
                {
                    elementArray[select].transform.rotation = Quaternion.Euler(-90, 0, 0);
                    elementArray[select].transform.localPosition = new Vector3 (17.0625f, 0, 0.75f);
                    Progress();
                }
            }
            if (select == 2 && point == 4) // element 5
            {
                if (eulerAngZ == 0)
                {
                    elementArray[select].transform.rotation = Quaternion.Euler(-90, 0, 0);
                    elementArray[select].transform.localPosition = new Vector3 (8.25f, 0, 1.5f);
                    Progress();
                }
            }
            if (select == 3 && point == 0) // element 1
            {
                if (eulerAngZ == 0 || eulerAngZ == 180)
                {
                    elementArray[select].transform.rotation = Quaternion.Euler(-90, 0, 0);
                    elementArray[select].transform.localPosition = new Vector3 (4.5f, 0, 0);
                    Progress();
                }
            }
            if (select == 4 && point == 2) // element 2
            {
                if (eulerAngZ <= 1)
                {
                    elementArray[select].transform.rotation = Quaternion.Euler(-90, 0, 0);
                    elementArray[select].transform.localPosition = new Vector3 (5.75f, 0, -1);
                    Progress();
                }
            }
        }


        // Leave / finish puzzle
        if (Input.GetKeyDown (KeyCode.Escape) || solved == 5)
        {
            Finished();
        }
    }


    void SelectDown()
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
            Vector3 position = selector.transform.position;
            position.y -= (check - select) * yOffset;
            selector.transform.position = position;
            select = check;
        }
    }


    void SelectUp()
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
            Vector3 position = selector.transform.position;
            position.y += (select - check) * yOffset;
            selector.transform.position = position;
            select = check;
        }
    }


    void PointRight()
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


    void PointLeft()
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


    void Progress()
    {
        imageArray[select].gameObject.SetActive(false);
        active[select] = false;
        placed[point] = false;
        solved += 1;
        int check = select;
        SelectDown();
        if (check == select)
        {
            SelectUp();
        }
        // select = check;
        check = point;
        PointRight();
        if (check == point)
        {
            PointLeft();
        }
        // point = check;
    }


    void Finished()
    {
        puzzleCamera.SetActive(false);
        indicator.SetActive(false);
        human.GetComponent<CharacterController>().enabled = true;
        if (solved == 5)
        {
            Destroy(this);
        }
    }
}
