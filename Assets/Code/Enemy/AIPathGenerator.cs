using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPathGenerator : MonoBehaviour
{
    private int m_XPos;
    private int m_ZPos;
    public GameObject Agent;

    private void Start()
    {
        m_XPos = Random.Range(-4, 15);
        m_ZPos = Random.Range(-4, 15);
        transform.position = new Vector3(m_XPos, 1, m_ZPos);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Collided");

        if (other.tag == "Enemy")
        {
            m_XPos = Random.Range(-4, 15);
            m_ZPos = Random.Range(-4, 15);
            transform.position = new Vector3(m_XPos, 1, m_ZPos);
        }
    }

    // VIDEO: https://www.youtube.com/watch?v=TL4XLomQl7U
}
