using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    public GameObject neededItem;
    public GameObject text;
    public string textMessage;

    public void interact(GameObject playerItem)
    {
        if (neededItem == null || ReferenceEquals(playerItem, neededItem))
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        else
        {
            text.SetActive(true);
            text.GetComponent<Text>().text = textMessage;
            StartCoroutine(textDissappear());
        }
    }

    IEnumerator textDissappear()
    {
        yield return new WaitForSecondsRealtime(6);
        if (text.GetComponent<Text>().text == textMessage)
        {
            text.SetActive(false);
        }
    }
}
