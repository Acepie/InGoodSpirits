using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TODO: Remove INPC after testing or make dummy
/// <summary>
/// Represents player class. Should remove INPC. Currently used for testing
/// </summary>
public class Player : MonoBehaviour, INPC {

    public float speed = 5f;
    Rigidbody2D rb2d;
    IInteractable interactableHoveringOver;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        OnHover();
        Move();
        if(interactableHoveringOver != null && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space");
            interactableHoveringOver.OnInteract(this);
        }
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
        interactableHoveringOver = null;
        if (go != null)
        {
            MonoBehaviour[] list = go.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour mb in list)
            {
                if (mb is IInteractable)
                {
                    interactableHoveringOver = (IInteractable)mb;
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

    public void SetVelocity(Vector3 vel)
    {
        throw new System.NotImplementedException();
    }

    public void AddAction(IAction a)
    {
        //TODO: Remove code. Only used for testing elevator action(s)
        IEnumerator actionCoroutine;
        actionCoroutine = a.DoAction();
        StartCoroutine(actionCoroutine);
    }

    public void SetPos(Vector3 v)
    {
        transform.position = v;
    }

}
