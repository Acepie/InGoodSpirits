﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 5f;
    Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        OnHover();
        Move();
    }

    private void Move()
    {
        Vector2 velocity = new Vector2(0, 0);
        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            velocity += new Vector2(-speed, 0);
        }

        if(Input.GetKey("right") || Input.GetKey("d"))
        {
            velocity += new Vector2(speed, 0);
        }

        if(Input.GetKey("up") || Input.GetKey("w"))
        {
            velocity += new Vector2(0, speed);
        }

        if(Input.GetKey("down") || Input.GetKey("s"))
        {
            velocity += new Vector2(0, -speed);
        }
        rb2d.velocity = velocity;
    }

    private void OnHover()
    {
        ///Updates Focus of current object, from building, to tower, to enemy
            GameObject go = GameObjectBelowMouse();
            if (go != null)
            {
                MonoBehaviour[] list = go.GetComponents<MonoBehaviour>();
                foreach (MonoBehaviour mb in list)
                {
                    if (mb is IInteractable)
                    {
                        IInteractable interactable = (IInteractable)(mb);
                        interactable.OnInteract(this);
                    }
                }
            }
    }

    private GameObject GameObjectBelowMouse()
    {
        GameObject clickedObject = null;

        Camera cam = Camera.main;
        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            clickedObject = hit.collider.gameObject;
        }

        return clickedObject;
    }
}