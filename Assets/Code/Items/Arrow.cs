using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody RB;
    public float FirePower;
    public float Torque;

    private GameObject m_PlayerHand;

    private void Start()
    {
        m_PlayerHand = GameObject.FindGameObjectWithTag("Hand");

        transform.rotation = new Quaternion(m_PlayerHand.transform.rotation.x, m_PlayerHand.transform.rotation.y, m_PlayerHand.transform.rotation.z, m_PlayerHand.transform.rotation.w);
        transform.position = m_PlayerHand.transform.position;
        RB.isKinematic = false;
        RB.AddForce(m_PlayerHand.transform.TransformDirection(Vector3.forward * FirePower), ForceMode.Impulse);
        RB.AddTorque(transform.right * Torque);
        transform.SetParent(null);
    }
}