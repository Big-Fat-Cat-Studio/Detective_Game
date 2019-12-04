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
    Vector3[] positionArray = new[] {
        new Vector3 (4.5f, 0, -1),
        new Vector3 (6.25f, 0, 1),
        new Vector3 (7, 0, -2),
        new Vector3 (7.25f, 0, 3),
        new Vector3 (8.25f, 0, 1.25f)
    };

    int select = 0;
    int point = 0;
    int elements = 5;
    int max;
    float yOffset = 0.46f;

    [HideInInspector]
    public bool solved = false;
    [HideInInspector]
    public int placed = 0;


    void Start()
    {
        max = elements - 1;
        // randomize stuff a bit (don't change last one, bugs out)
        imageArray[0].transform.Rotate(0, 0, 90);
        imageArray[1].transform.Rotate(0, 0, 0);
        imageArray[2].transform.Rotate(0, 0, 90);
        imageArray[3].transform.Rotate(0, 0, 90);
        imageArray[4].transform.Rotate(0, 0, 0);
    }


    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Human")
        {
            puzzleCamera.SetActive(true);
            indicator.SetActive(true);
        }
    }


    void Update()
    {
        // Move pipe selector
        if (Input.GetKeyDown (KeyCode.DownArrow))
        {
            if (select < elements - 1)
            {
                select++;
                Vector3 position = selector.transform.position;
                position.y -= yOffset;
                selector.transform.position = position;
            }
        }
        if (Input.GetKeyDown (KeyCode.UpArrow))
        {
            if (select > 0)
            {
                select--;
                Vector3 position = selector.transform.position;
                position.y += yOffset;
                selector.transform.position = position;
            }
        }


        // Rotate selection
        if (Input.GetKeyDown (KeyCode.Space))
        {
            imageArray[select].transform.Rotate(0, 0, -90);
        }


        // Move indicator
        if (Input.GetKeyDown (KeyCode.LeftArrow))
        {
            Vector3 position = indicator.transform.localPosition;
            if (point == 0)
            {
                point = max;
            }
            else
            {
                point--;
            }
            position = positionArray[point];
            indicator.transform.localPosition = position;
        }
        if (Input.GetKeyDown (KeyCode.RightArrow))
        {
            Vector3 position = indicator.transform.localPosition;
            if (point == max)
            {
                point = 0;
            }
            else
            {
                point++;
            }
            position = positionArray[point];
            indicator.transform.localPosition = position;
        }


        // Check if correct
        if (Input.GetKeyDown (KeyCode.Return))
        {
            float eulerAngZ = imageArray[select].transform.localEulerAngles.z;
            if (select == 0 && point == 3) // element 4
            {
                if (eulerAngZ == 180)
                {
                    imageArray[select].gameObject.SetActive(false);
                    elementArray[select].transform.rotation = Quaternion.Euler(180, 0, 0);
                    elementArray[select].transform.localPosition = new Vector3 (7.25f, 0, 3);
                    placed += 1;
                }
            }
            if (select == 1 && point == 1) // element 3
            {
                if (eulerAngZ == 0 || eulerAngZ == 180)
                {
                    imageArray[select].gameObject.SetActive(false);
                    elementArray[select].transform.rotation = Quaternion.Euler(-90, 0, 0);
                    elementArray[select].transform.localPosition = new Vector3 (17.0625f, 0, 0.75f);
                    placed += 1;
                }
            }
            if (select == 2 && point == 4) // element 5
            {
                if (eulerAngZ == 0)
                {
                    imageArray[select].gameObject.SetActive(false);
                    elementArray[select].transform.rotation = Quaternion.Euler(-90, 0, 0);
                    elementArray[select].transform.localPosition = new Vector3 (8.25f, 0, 1.5f);
                    placed += 1;
                }
            }
            if (select == 3 && point == 0) // element 1
            {
                if (eulerAngZ == 0 || eulerAngZ == 180)
                {
                    imageArray[select].gameObject.SetActive(false);
                    elementArray[select].transform.rotation = Quaternion.Euler(-90, 0, 0);
                    elementArray[select].transform.localPosition = new Vector3 (4.5f, 0, 0);
                    placed += 1;
                }
            }
            if (select == 4 && point == 2) // element 2
            {
                if (eulerAngZ == 0)
                {
                    imageArray[select].gameObject.SetActive(false);
                    elementArray[select].transform.rotation = Quaternion.Euler(-90, 0, 0);
                    elementArray[select].transform.localPosition = new Vector3 (5.75f, 0, -1);
                    placed += 1;
                }
            }
        }


        // Leave puzzle
        if (Input.GetKeyDown (KeyCode.Escape))
        {
            puzzleCamera.SetActive(false);
            indicator.SetActive(false);
        }


        // Check if puzzle is solved
        if (placed == 5)
        {
            solved = true;
            puzzleCamera.SetActive(false);
            indicator.SetActive(false);
            Destroy(this);
        }
    }
}
