using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuPlayImageLoader : MonoBehaviour, ISelectHandler
{
    public GameObject Target;
    public Sprite Image;

    public void OnSelect(BaseEventData eventData)
    {
        Target.GetComponent<Image>().sprite = Image;
    }
}
