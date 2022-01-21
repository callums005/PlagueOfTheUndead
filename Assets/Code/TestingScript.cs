using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (InputSystem.GetDevice<Keyboard>().rKey.wasPressedThisFrame)
        {
            GameManager.AmendHealth(50, '-');
        }
    }
}
