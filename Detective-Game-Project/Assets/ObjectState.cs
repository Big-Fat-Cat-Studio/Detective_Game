using Scripts;
using UnityEngine;

public class ObjectState : MonoBehaviour
{
    public InteractState State { get; set; } = InteractState.DEACTIVATED;
}