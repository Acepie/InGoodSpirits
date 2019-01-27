﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorBell : MonoBehaviour, PlayerInteractable
{
    public UnityEvent doorBellRang = new UnityEvent();
    public AudioClip ringClip;
    public Sprite normalSprite;
    public Sprite glowSprite;
    public SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public void OnInteract(Player n)
    {
        SoundManager.PlaySound(ringClip);
        doorBellRang.Invoke();
    }

    private void OnMouseEnter()
    {
        sr.color = Color.yellow;
    }

    private void OnMouseExit()
    {
        sr.color = Color.white;
    }
}
