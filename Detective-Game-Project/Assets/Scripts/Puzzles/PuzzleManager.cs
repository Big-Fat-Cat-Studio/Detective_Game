using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject PuzzleCamera;
    public GameObject Indicator;


    void Start()
    {

    }


    void Update()
    {
        if (Input.GetButtonDown("Swap"))
        {
            if (PuzzleCamera.activeSelf == true)
            {
                PuzzleCamera.SetActive(false);
                Indicator.SetActive(false);
            }
            else
            {
                PuzzleCamera.SetActive(true);
                Indicator.SetActive(true);

            }
        }
    }
}
