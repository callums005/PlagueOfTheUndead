using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody RB;
    public float Speed;
    public ForceMode Force;

    private GameObject m_Player;

    private void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");

        transform.position = m_Player.transform.position;
    }

    private void Update()
    {
        RB.AddForce(Speed * Time.deltaTime * m_Player.transform.forward, Force);
    }
}