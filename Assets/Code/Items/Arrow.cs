using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody RB;
    public float FirePower;
    public ForceMode Force;
    public float Torque;
    public float Range;

    private GameObject m_PlayerHand;

    private Vector3 m_StartDistance;
    private bool m_ApplyDownForce = false;
    private bool m_Debouce = false;

    private void Start()
    {
        m_PlayerHand = GameObject.FindGameObjectWithTag("Hand");

        transform.rotation = new Quaternion(m_PlayerHand.transform.rotation.x, m_PlayerHand.transform.rotation.y, m_PlayerHand.transform.rotation.z, m_PlayerHand.transform.rotation.w);
        transform.position = m_PlayerHand.transform.position;
        m_StartDistance = m_PlayerHand.transform.position;
        RB.isKinematic = false;
        RB.AddForce(transform.up * Range, ForceMode.Impulse);
        RB.AddForce(m_PlayerHand.transform.TransformDirection(Vector3.forward * FirePower), Force);
        RB.AddTorque(transform.right * Torque);
        transform.SetParent(null);
    }

    private void Update()
    {
        if (Vector3.Distance(m_StartDistance, transform.position) > Range && m_ApplyDownForce == false)
            m_ApplyDownForce = true;

        if (m_ApplyDownForce && !m_Debouce)
        {
            m_Debouce = true;
            RB.AddForce(-(transform.up * Range), ForceMode.Impulse);
        }

    }
}