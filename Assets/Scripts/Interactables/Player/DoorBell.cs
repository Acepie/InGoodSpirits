using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorBell: MonoBehaviour, PlayerInteractable
{
    public UnityEvent doorBellRang = new UnityEvent();
    public AudioClip ringClip;

    public void OnInteract(Player n)
    {
        SoundManager.PlaySound(ringClip);
        doorBellRang.Invoke();
    }
}
