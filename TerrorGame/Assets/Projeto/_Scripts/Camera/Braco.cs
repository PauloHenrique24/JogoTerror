using UnityEngine;
using UnityEngine.InputSystem;

public class Braco : MonoBehaviour
{
    private PlayerInputActions inputActions;
    private Vector2 mousePosition;

    private Camera mainCamera;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.Player.Look.performed += ctx => mousePosition = ctx.ReadValue<Vector2>();
        inputActions.Player.Look.canceled += ctx => mousePosition = ctx.ReadValue<Vector2>();

        mainCamera = Camera.main;
    }

    private void Update()
    {
        Vector3 worldMousePos = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, mainCamera.nearClipPlane));
        Vector3 direction = worldMousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotação no eixo Z apenas
        transform.rotation = Quaternion.Euler(0f, 0f, angle + 150); // "-90" ajusta para sprites com frente voltada para cima
    }
}
