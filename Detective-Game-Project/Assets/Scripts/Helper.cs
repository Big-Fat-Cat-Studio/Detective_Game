using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public class Helper : MonoBehaviour
{
    /// <summary>
    /// General function for basic object interaction
    /// </summary>
    /// <param name="staticObj">Object "player" will interact with</param>
    /// <param name="movingObj">Player object</param>
    /// <param name="range">Within which range should the interaction take place</param>
    /// <param name="Actions">In/Out of range functions to execute</param>
    public static void InteractGeneral(GameObject staticObj, GameObject movingObj, float range, Tuple<Action, Action> Actions)
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

    /// <summary>
    /// Checks wether or not two given objects are in range of eachother
    /// </summary>
    /// <param name="obj1">First object</param>
    /// <param name="obj2">Second Object</param>
    /// <param name="range">Max range</param>
    /// <returns></returns>
    public static bool WithinRange(GameObject obj1, GameObject obj2, float range)
    {
        Debug.Log($"In range : {Vector3.Distance(obj2.transform.position, obj1.transform.position) <= range} " +
                    $"|||||| Distance {Vector3.Distance(obj2.transform.position, obj1.transform.position)}");

        return (Vector3.Distance(obj2.transform.position, obj1.transform.position) <= range);
    }

    public static GameObject ClosestToTarget(List<GameObject> pool, GameObject target)
    {
        // Loop through all values
        // Store first value
        // Check if second value is smaller than first value, if so, second value = first value
        // Repeat

        GameObject? lowest = null;

        foreach (GameObject ob in pool)
        {
            if (lowest == true)
                lowest = ob;

            lowest =
                (Vector3.Distance(ob.transform.position, target.transform.position) <
                Vector3.Distance(lowest.transform.position, target.transform.position))
                ? ob : lowest;
        }
        return lowest;
    }
}
