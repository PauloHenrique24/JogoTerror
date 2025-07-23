using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{

    [Header("Limites de Rotação Vertical (X)")]
    public float minX = -60f;
    public float maxX = 60f;

    [Header("Limites de Rotação Horizontal (Y)")]
    public float minY = -180f;
    public float maxY = 180f;

    private Vector2 lookInput;
    private float rotationX = 0f; // Pitch (vertical)
    private float rotationY = 0f; // Yaw (horizontal)

    private PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.Player.Look.performed += OnLook;
        inputActions.Player.Look.canceled += OnLook;
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
        float mouseX = lookInput.x * GameController.MouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * GameController.MouseSensitivity * Time.deltaTime;

        rotationY += mouseX;
        rotationX -= mouseY;

        rotationX = Mathf.Clamp(rotationX, minX, maxX);
        rotationY = Mathf.Clamp(rotationY, minY, maxY);

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }
}
