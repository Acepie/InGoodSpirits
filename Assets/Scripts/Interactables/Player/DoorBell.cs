using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorBell: MonoBehaviour, PlayerInteractable
{
    public UnityEvent doorBellRang = new UnityEvent();

    public void OnInteract(Player n)
    {
        Debug.Log("Interact");
        doorBellRang.Invoke();
    }
}
