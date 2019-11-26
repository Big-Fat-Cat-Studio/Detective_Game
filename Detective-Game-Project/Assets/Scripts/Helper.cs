using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Helper : MonoBehaviour
{
    /// <summary>
    /// General function for basic object interaction.
    /// </summary>
    /// <param name="staticObj">Object "player" will interact with.</param>
    /// <param name="movingObj">Player object.</param>
    /// <param name="range">Within which range should the interaction take place.</param>
    /// <param name="Actions">In/Out of range functions to execute.</param>
    public static void InteractGeneral(GameObject staticObj, GameObject movingObj, float range, Tuple<Action,Action> Actions)
    {
        if (Vector3.Distance(staticObj.transform.position, movingObj.transform.position) <= range)
        {
            RaycastHit hit;
            if (Physics.Raycast(movingObj.transform.position, movingObj.transform.forward, out hit, Mathf.Infinity))
            {
                Debug.DrawRay(movingObj.transform.position, movingObj.transform.forward * hit.distance, Color.yellow);
                Actions.Item1();
            }
            else
            {
                Debug.DrawRay(movingObj.transform.position, movingObj.transform.forward * 1000, Color.white);
                Actions.Item2();
            }
        }
    }
}
