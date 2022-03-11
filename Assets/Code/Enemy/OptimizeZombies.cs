using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimizeZombies : MonoBehaviour
{
    public GameObject ZombieParent;
    public GameObject Player;
    public float Range;

    private GameObject[] m_ZombieArray;

    private void Start()
    {
        PopulateArray();
    }

    private void Update()
    {
        if (m_ZombieArray.Length != ZombieParent.transform.childCount)
        {
            PopulateArray();
        }

        foreach(GameObject zombie in m_ZombieArray)
        {
            if (Vector3.Distance(Player.transform.position, zombie.transform.position) > Range)
                zombie.SetActive(false);
            else
                zombie.SetActive(true);
        }
    }

    private void PopulateArray()
    {
        int count = 0;
        m_ZombieArray = new GameObject[ZombieParent.transform.childCount];

        foreach (Transform child in ZombieParent.transform)
        {
            m_ZombieArray[count] = child.gameObject;
            count++;
        }
    }
}
