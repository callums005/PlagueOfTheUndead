using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public GameObject Player;

    /// <summary>
    ///     This function uses an find min algorithm to calculate the shortest distance from the enemy to the player,
    ///     in turn, being the closest to the player
    /// </summary>
    /// 
    /// <returns>GameObject: Closest Enemy</returns>
    /// 
    public GameObject GetNearestEnemy()
    {
        GameObject[] agents = GameObject.FindGameObjectsWithTag("Enemy");

        GameObject nearest = agents[0];

        for (int i = 1; i < agents.Length; i++)
        {
            GameObject agent = agents[i];

            if (Vector3.Distance(agent.transform.position, Player.transform.position) < Vector3.Distance(nearest.transform.position, Player.transform.position))
                nearest = agent;
        }

        return nearest.transform.parent.gameObject;
    }
}
