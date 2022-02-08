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
    }

    private void Update()
    {
        RB.AddForce(m_Player.transform.forward * Speed * Time.deltaTime, Force);
    }
}