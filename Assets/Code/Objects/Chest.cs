using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public InputManager InputManager;
    public GameObject Player;

    public float Radius;

    private void Update()
    {
        if (!InputManager.GetUsingState())
            return;

        if (Vector3.Distance(Player.transform.position, transform.position) > Radius)
            return;

        Debug.Log("Use Chest");
    }
}
