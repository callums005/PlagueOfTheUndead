using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPathGenerator : MonoBehaviour
{
    private int m_XPos;
    private int m_ZPos;
    public GameObject Agent;
    public LayerMask InvalidSpawnLayers;
    public Transform Check;

    public int MinRange;
    public int MaxRange;

    public bool isInObject;

    private void Start()
    {
        m_XPos = Random.Range(MinRange, MaxRange);
        m_ZPos = Random.Range(MinRange, MaxRange);
        transform.position = new Vector3(m_XPos, 1, m_ZPos);

        isInObject = Physics.CheckSphere(Check.position, 0.2f, InvalidSpawnLayers);

        while (isInObject)
        {
            m_XPos = Random.Range(MinRange, MaxRange);
            m_ZPos = Random.Range(MinRange, MaxRange);
            transform.position = new Vector3(m_XPos, 1, m_ZPos);
            isInObject = Physics.CheckSphere(Check.position, 0.2f, InvalidSpawnLayers);
        }

    }

    private void Update()
    {
        isInObject = Physics.CheckSphere(Check.position, 0.2f, InvalidSpawnLayers);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Agent)
            StartCoroutine(ReachedTargetDelay());
    }

    
    private IEnumerator ReachedTargetDelay()
    {
        yield return new WaitForSeconds(Agent.GetComponent<EnemyMovement>().AgentReachedPathTargetDelay);

        m_XPos = Random.Range(MinRange, MaxRange);
        m_ZPos = Random.Range(MinRange, MaxRange);
        transform.position = new Vector3(m_XPos, 1, m_ZPos);

        isInObject = Physics.CheckSphere(Check.position, 0.2f, InvalidSpawnLayers);

        while (isInObject)
        {
            m_XPos = Random.Range(MinRange, MaxRange);
            m_ZPos = Random.Range(MinRange, MaxRange);
            transform.position = new Vector3(m_XPos, 1, m_ZPos);
            isInObject = Physics.CheckSphere(Check.position, 0.2f, InvalidSpawnLayers);
        }
    }

    // VIDEO: https://www.youtube.com/watch?v=TL4XLomQl7U
}
