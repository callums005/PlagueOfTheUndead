using UnityEngine;
using Cinemachine;

public class InputManager : MonoBehaviour
{
    /// <summary>
    /// This class is responsible for handling player input using the new InputSystem Unity provides in the package manager.
    /// </summary>

    private Controls m_Controls;

    [Header("Controls")]
    public bool Menu = false;
    public bool Player = false;

    [Header("Game Objects")]
    public CinemachineFreeLook FreeLookCamera;

    [Header("Scripts")]
    public InventoryManager InventoryManager;

    private Vector2 m_MoveValue;
    private Vector2 m_CameraValue;
    private bool m_IsJumping;
    private bool m_Using;

    private void Awake()
    {
        m_Controls = new Controls();

        if (Player)
        {
            m_Controls.Player.Move.performed += ctx => m_MoveValue = ctx.ReadValue<Vector2>();
            m_Controls.Player.Move.canceled += ctx => m_MoveValue = Vector2.zero;

            m_Controls.Player.Camera.performed += ctx => m_CameraValue = ctx.ReadValue<Vector2>();
            m_Controls.Player.Camera.canceled += ctx => m_CameraValue = Vector2.zero;

            m_Controls.Player.Jump.performed += ctx => SetJumpValue(true);
            m_Controls.Player.Jump.canceled += ctx => SetJumpValue(false);

            m_Controls.Player.SwitchWeapon.performed += ctx => InventoryManager.SwitchWeapon();
            m_Controls.Player.UseConsumable.performed += ctx => InventoryManager.UseConsumable();
            m_Controls.Player.Attack.performed += ctx => InventoryManager.UseSelectedItem();

            m_Controls.Player.Use.performed += ctx => SetUseValue(true);
            m_Controls.Player.Use.canceled += ctx => SetUseValue(false);
        }
        else if (Menu)
        {

        }
    }

    private void Update()
    {
        if (!GameManager.CanMoveCamera)
            return;

        if (Menu)
            return;

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

    private void SetUseValue(bool value)
    {
        m_Using = value;
    }

    public bool GetUsingState()
    {
        return m_Using;
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
