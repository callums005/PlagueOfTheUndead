using UnityEngine;

public class Billboard : MonoBehaviour
{
    private GameObject m_Camera;

    void Start()
    {
        m_Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + m_Camera.transform.forward);
    }
}
