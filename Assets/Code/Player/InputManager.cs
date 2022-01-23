using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InputManager : MonoBehaviour
{
    private Controls m_Controls;

    [Header("Controls")]
    public bool Menu = false;
    public bool Player = false;

    [Header("Game Objects")]
    public CinemachineFreeLook FreeLookCamera;

    private Vector2 m_MoveValue;
    private Vector2 m_CameraValue;
    private bool m_IsJumping;

    private void Awake()
    {
        m_Controls = new Controls();

        if (Player)
        {
            m_Controls.Player.Move.performed += ctx => m_MoveValue = ctx.ReadValue<Vector2>();
            m_Controls.Player.Move.canceled += ctx => m_MoveValue = Vector2.zero;

            m_Controls.Player.Camera.performed += ctx => m_CameraValue = ctx.ReadValue<Vector2>();
            m_Controls.Player.Camera.canceled += ctx => m_CameraValue = Vector2.zero;

            m_Controls.Player.JumpUse.performed += ctx => SetJumpValue(true);
            m_Controls.Player.JumpUse.canceled += ctx => SetJumpValue(false);
        }
        else if (Menu)
        {

        }
    }

    private void Update()
    {
        FreeLookCamera.m_XAxis.m_InputAxisValue = m_CameraValue.x;
        FreeLookCamera.m_YAxis.m_InputAxisValue = m_CameraValue.y;
    }

    private void SetJumpValue(bool value)
    {
        m_IsJumping = value;
    }

    public bool GetJumpingState()
    {
        return m_IsJumping;
    }

    public Vector2 GetMoveValue()
    {
        return m_MoveValue;
    }

    #region Enabalers

    private void OnEnable()
    {
        if (Player)
        {
            m_Controls.Player.Enable();
        }
        else if (Menu)
        {
            m_Controls.Menu.Enable();
        }
    }

    private void OnDisable()
    {
        if (Player)
        {
            m_Controls.Player.Disable();
        }
        else if (Menu)
        {
            m_Controls.Player.Disable();
        }
    }

    #endregion
}