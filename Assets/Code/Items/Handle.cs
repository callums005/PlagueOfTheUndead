using UnityEngine;

public class Handle : MonoBehaviour
{
    public Vector3 position;
    public Vector3 rotation;
    
    private GameObject handle;

    private void Start()
    {
        handle = GameObject.FindGameObjectWithTag("Hand");

        if (handle != null)
        {
            transform.parent = handle.transform;
            transform.localPosition = position;
            transform.localEulerAngles = rotation;
        }
    }
}