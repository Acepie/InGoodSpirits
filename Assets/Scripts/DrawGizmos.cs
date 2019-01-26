using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmos : MonoBehaviour
{
    public Color c;
    public float radius;

    private void OnDrawGizmos()
    {
        Gizmos.color = c;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
