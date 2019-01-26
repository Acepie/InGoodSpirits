using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AbstractInteractable : MonoBehaviour, IInteractable {

    public void OnInteract(Player p)
    {
        Debug.Log("Hovering over" + this.name);
    }

}
