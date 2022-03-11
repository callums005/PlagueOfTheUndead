using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    [Header("Interactable Settings")]
    [Range(0f, 5f)]
    public float Radius = 3;

    private GameObject m_Player;

    private void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
    }

    public bool IsInRange()
    {
        if (!InputSystem.GetDevice<Keyboard>().fKey.wasPressedThisFrame)
            return false;

        if (Vector3.Distance(m_Player.transform.position, transform.position) > Radius)
            return false;

        return true;
    }

    public void UpdateUI()
    {

    }
}