using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPathGenerator : MonoBehaviour
{
    /// <summary>
    /// This class will generate paths for AI enemies when it is not following the player
    /// </summary>

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
        StartCoroutine(ReachedTargetDelay(true));

    }

    /// <summary>
    /// If the collider is the enemy agent then it will start a coroutine that will create a new path target
    /// </summary>
    /// <param name="other">Collider: this is the object that collides with the trigger</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Agent)
            StartCoroutine(ReachedTargetDelay(false));
    }

    /// <summary>
    /// This function will do the following steps to create a random path for the AI to follow
    ///     - Create a random X and Z position within the positive and negative values of the radius
    ///     - set the object's position to the current enemy spawn position plus the X and Z position
    ///     - Checks to see if the path is invalid (too close to the previous path, or is inside any layer that is collidable
    ///     - If the oath is invalid, it will recreate it and check again
    /// </summary>
    /// <param name="skip">bool: skips wait if true</param>
    private IEnumerator ReachedTargetDelay(bool skip)
    {
        if (!skip)
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
