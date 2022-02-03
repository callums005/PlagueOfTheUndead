using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform Target;
    public NavMeshAgent Agent;

    private Vector3 m_Position;

    private void Update()
    {
        if (m_Position != Target.position)
        {
            Agent.SetDestination(Target.position);
        }
    }
}
