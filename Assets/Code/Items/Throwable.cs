using UnityEngine;

public class Throwable : MonoBehaviour
{
    public Rigidbody RB;
    public float FirePower;
    public float Torque;

    private GameObject m_PlayerHand;


    /// <summary>
    /// Spawns an object at the players hand, adds a forward force to move the object forward.
    /// </summary>
    private void Start()
    {
        m_PlayerHand = GameObject.FindGameObjectWithTag("Hand");

        transform.rotation = new Quaternion(m_PlayerHand.transform.rotation.x, m_PlayerHand.transform.rotation.y, m_PlayerHand.transform.rotation.z, m_PlayerHand.transform.rotation.w);
        RB.isKinematic = false;
        RB.AddForce(m_PlayerHand.transform.TransformDirection(Vector3.forward * FirePower), ForceMode.Impulse);
        RB.AddTorque(transform.right * Torque);
        transform.SetParent(null);
    }
}