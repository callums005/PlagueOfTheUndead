using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float FollowRadius = 3f;

    public Transform Player;
    public Transform PathTarget;
    public NavMeshAgent Agent;

    private Vector3 m_Position;
 

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
            Vector3 lookDirection = (PathTarget.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(lookDirection.x, 0, lookDirection.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

            if (Agent.transform.position != PathTarget.position)
            {
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
