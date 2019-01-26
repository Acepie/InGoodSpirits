using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, INPC {

    public float speed;
    Rigidbody2D rb2d;
    bool isMoving = false;
    IEnumerator coroutine;
    public Routine routines;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        routines = GetComponent<Routine>();
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            routines.AddAction(new MoveTo(mousePos, this));
        }
	}

    public void SetVelocity(Vector3 vel)
    {
        rb2d.velocity = vel;
    }

    public void AddAction(IAction a)
    {
        routines.AddAction(a);
    }

    public Vector3 GetPos()
    {
        return transform.position;
    }

    public void SetPos(Vector3 v)
    {
        transform.position = v;
    }
}
