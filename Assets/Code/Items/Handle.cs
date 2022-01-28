using UnityEngine;

public class Handle : MonoBehaviour
{
    public Transform handle;

    private void Update()
    {
        transform.localPosition = handle.position;
    }
}