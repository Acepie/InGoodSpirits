using UnityEngine;

public class AbstractPickupInteractable : MonoBehaviour, PlayerInteractable
{
    public virtual void OnInteract(Player p)
    {
        p.PickUp(this);
        transform.parent = p.transform;
        transform.localScale = new Vector3(.5f, .5f, 1);
    }

    public virtual void Drop(Vector3 v)
    {
        transform.parent = null;
    }
}