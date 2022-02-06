using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [Header("Agent Settings")]
    public NavMeshAgent Agent;
    public float FollowRadius = 3f;
    public float AgentReachedPathTargetDelay = 2f;

    [Header("Agent Targets")]
    public Transform Player;
    public Transform PathTarget;

    [Header("Agent Spawn")]
    public GameObject SpawnPoint;
    public int SpawnRadius;


    private Vector3 m_Position;

    private void Start()
    {
        int x = Random.Range(-SpawnRadius, SpawnRadius);
        int z = Random.Range(-SpawnRadius, SpawnRadius);

        transform.position = SpawnPoint.transform.position + new Vector3(x, transform.position.y, z);
    }


    private void Update()
    {
        float distance = Vector3.Distance(Player.position, transform.position);

        if (distance <= FollowRadius)
        {
            Vector3 lookDirection = (Player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(lookDirection.x, 0, lookDirection.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

            if (Agent.transform.position != Player.position)
            {
                Agent.SetDestination(Player.position);
            }
        }
        else
        {
            if (Agent.transform.position != PathTarget.position)
            {
                //Vector3 lookDirection = (PathTarget.position - transform.position).normalized;
                //Quaternion lookRotation = Quaternion.LookRotation(new Vector3(lookDirection.x, 0, lookDirection.z));
                //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

                Agent.SetDestination(PathTarget.position);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, FollowRadius);
    }
}
