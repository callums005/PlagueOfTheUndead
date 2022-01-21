using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController Controller;
    public Transform GameCamera;

    [Header("Settings")]
    public float Speed = 6f;
    public float JumpHeight = 2.0f;
    public float TurnTime = 0.1f;
    [Space()]
    public float Gravity = -19.62f;
    [Space()]
    public float GroundDistance = 0.2f;
    public LayerMask GroundMask;

    [Header("Game Objects")]
    public InputManager InputManager;
    public Transform GroundCheck;

    private float m_TurnSmoothm_Velocity;
    private Vector3 m_Velocity;
    private bool m_IsGrounded;

    private void Update()
    {
        // Y axis Movment
        m_IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (m_IsGrounded && m_Velocity.y < 0)
            m_Velocity.y = -2f;

        if (m_IsGrounded && InputManager.GetJumpingState())
            m_Velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);

        // X and Z Axis Movement
        Vector2 movement = InputManager.GetMoveValue();
        Vector3 direction = new Vector3(movement.x, 0, movement.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + GameCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref m_TurnSmoothm_Velocity, TurnTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            Controller.Move(moveDir.normalized * Speed * Time.deltaTime);
        }

        // Gravity Physics
        m_Velocity.y += Gravity * Time.deltaTime;
        Controller.Move(m_Velocity * Time.deltaTime);
    }
}
