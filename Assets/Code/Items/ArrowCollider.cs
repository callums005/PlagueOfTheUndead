using System;
using UnityEngine;

public class ArrowCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
            throw new NotImplementedException();
    }
}