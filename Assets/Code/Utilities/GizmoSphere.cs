using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoSphere : MonoBehaviour
{
    public float Size;
    public Color Colour;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Colour;
        Gizmos.DrawWireSphere(transform.position, Size);
    }
}
