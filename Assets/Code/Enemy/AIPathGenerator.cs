using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPathGenerator : MonoBehaviour
{
    public GameObject Agent;
    public GameObject AgentSpawn;
    [Header("Check Settings")]
    public LayerMask InvalidSpawnLayers;
    public Transform Check;

    [Header("Distance Settings")]
    public int RangeRadius;
    public int MinDistance;

    private int m_ZPos;
    private int m_XPos;
    private bool isInObject;

    private void Start()
    {
        m_XPos = Random.Range(-RangeRadius, RangeRadius);
        m_ZPos = Random.Range(-RangeRadius, RangeRadius);
        transform.position = AgentSpawn.transform.position + new Vector3(m_XPos, 1, m_ZPos);

        isInObject = Physics.CheckSphere(Check.position, 0.2f, InvalidSpawnLayers);

        while (isInObject || Vector3.Distance(transform.position, Agent.transform.position) <= 4)
        {
            m_XPos = Random.Range(-RangeRadius, RangeRadius);
            m_ZPos = Random.Range(-RangeRadius, RangeRadius);
            transform.position = AgentSpawn.transform.position + new Vector3(m_XPos, 1, m_ZPos);
            isInObject = Physics.CheckSphere(Check.position, 0.2f, InvalidSpawnLayers);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Agent)
            StartCoroutine(ReachedTargetDelay());
    }

    private IEnumerator ReachedTargetDelay()
    {
        yield return new WaitForSeconds(Agent.GetComponent<EnemyMovement>().AgentReachedPathTargetDelay);

        m_XPos = Random.Range(-RangeRadius, RangeRadius);
        m_ZPos = Random.Range(-RangeRadius, RangeRadius);
        transform.position = AgentSpawn.transform.position + new Vector3(m_XPos, 1, m_ZPos);

        isInObject = Physics.CheckSphere(Check.position, 0.2f, InvalidSpawnLayers);

        while (isInObject || Vector3.Distance(transform.position, Agent.transform.position) <= 4)
        {
            m_XPos = Random.Range(-RangeRadius, RangeRadius);
            m_ZPos = Random.Range(-RangeRadius, RangeRadius);
            transform.position = AgentSpawn.transform.position + new Vector3(m_XPos, 1, m_ZPos);
            isInObject = Physics.CheckSphere(Check.position, 0.2f, InvalidSpawnLayers);
        }
    }
}
