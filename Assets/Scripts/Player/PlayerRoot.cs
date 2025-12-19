using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRoot : MonoBehaviour
{
    public Transform cameraHolder;

    private IMovement _movement;
    private IWeapon _weapon;
    private IMouseLook _mouseLook;

    private bool _isPaused = false;

    void Awake()
    {
        ServiceLocator.RegisterInput(new UnityInputService());
        ServiceLocator.RegisterPhysics(new UnityPhysicsService());

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        IPlayerFactory factory = new PlayerFactory();

        
        _movement = factory.CreateMovement(rb);
        PlayerMovement playerMovement = _movement as PlayerMovement;

        
        _weapon = factory.CreateWeapon(rb, cameraHolder, playerMovement);

        _mouseLook = new MouseLook(transform, cameraHolder);

        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandlePause();

        if (_isPaused) return;

        // Mouse look
        float mouseX = ServiceLocator.Input.HorizontalMouse();
        float mouseY = ServiceLocator.Input.VerticalMouse();
        _mouseLook.Look(mouseX, mouseY);

        _weapon.Tick();
    }

    void FixedUpdate()
    {
        if (_isPaused) return;
        _movement.FixedTick();
    }

    public float MouseSensitivity
    {
        get => _mouseLook.GetSensitivity();
        set => _mouseLook.SetSensitivity(value);
    }

    private void HandlePause()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            _isPaused = !_isPaused;

            if (_isPaused)
            {
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}