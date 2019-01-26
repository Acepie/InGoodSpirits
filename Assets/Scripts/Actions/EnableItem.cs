﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableItem : IAction
{
    public GameObject itemToEnable;

    public EnableItem(GameObject g)
    {
        itemToEnable = g;
        Debug.Log(itemToEnable.name);
    }

    public void SetItem(GameObject i)
    {
        itemToEnable = i;
    }
    public IEnumerator DoAction()
    {
        Debug.Log(Time.time);
        Debug.Log(itemToEnable.name + "im doing it");
        itemToEnable.GetComponent<Collider2D>().enabled = true;
        itemToEnable.GetComponent<SpriteRenderer>().enabled = true;
        yield return null;
    }
}