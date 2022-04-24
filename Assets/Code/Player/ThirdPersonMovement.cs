using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    /// <summary>
    /// This class is responsible for third person player movement and camera movement
    /// </summary>

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
    
    [Header("Animators")]
    public Animator KnightAnimator;
    public Animator MageAnimator;

    private float m_TurnSmoothm_Velocity;
    private Vector3 m_Velocity;
    private bool m_IsGrounded;

    /// <summary>
    /// The Update function is called once per frame, the function will do as follows:
    ///     - Create a invisble sphere underneath the player, if it collides with any object with the GroundMask layers
    ///       it will return true, otherwrise it will return false
    ///     - It will then check if the player is grounded and if the player has pressed the jump button
    ///       if so, it will move the player up
    ///     - It will read in the mouse movement/joysick movement values from the InputManager
    ///     - Calculate the normalised vector of where the player should move and by how much
    ///     - It will then move the character on the X and Z axis depending on the speed
    ///     - Finally it will move the character on the Y axis whilst applying gravity
    /// </summary>

    private void Update()
    {
        // Y axis Movment
        m_IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        // May be broken
        if (m_IsGrounded && m_Velocity.y < 0)
            m_Velocity.y = -2f;

        if (m_IsGrounded && InputManager.GetJumpingState())
            m_Velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);

        // X and Z Axis Movement
        Vector2 movement = InputManager.GetMoveValue();
        Vector3 direction = new Vector3(movement.x, 0, movement.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            if (GameManager.CharType == CharacterType.Knight)
                KnightAnimator.SetBool("IsWalking", true);
            else if (GameManager.CharType == CharacterType.Mage)
                MageAnimator.SetBool("IsWalking", true);

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + GameCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref m_TurnSmoothm_Velocity, TurnTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            Controller.Move(moveDir.normalized * Speed * Time.deltaTime);
        }
        else
        {
            if (GameManager.CharType == CharacterType.Knight)
                KnightAnimator.SetBool("IsWalking", false);
            else if (GameManager.CharType == CharacterType.Mage)
                MageAnimator.SetBool("IsWalking", false);
        }

        // Gravity Physics
        m_Velocity.y += Gravity * Time.deltaTime;
        Controller.Move(m_Velocity * Time.deltaTime);
    }
}
