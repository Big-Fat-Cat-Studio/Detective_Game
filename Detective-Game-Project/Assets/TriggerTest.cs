using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (ReferenceEquals(other.gameObject, Scripts.GameManager.Instance.Human)) { 
        Debug.Log($"Entering {GetInstanceID()}.");
        Debug.Log($"Colliding with {other.name}");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (ReferenceEquals(other.gameObject, Scripts.GameManager.Instance.Human)) { 
        Debug.Log($"Exiting {GetInstanceID()}.");
        Debug.Log($"Colliding with {other.name}");
        }
    }
}
