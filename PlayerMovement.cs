using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float MouseX;
    private float MouseY;
    private float XRot;
    private float YRot;
    private float VerticalAxis;
    private float HorizontalAxis;

    private Camera PlayerCam;

    [SerializeField] private float MovementSpeed;
    [SerializeField] private float MouseSensitivity;

    private void ConfigureCursor() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Start() {
        ConfigureCursor();
        PlayerCam = Camera.main;
    }

    private void HandleMovement() {
        // If you change the axis names, you need to change the arguments of the the GetAxis() calls below
        VerticalAxis = Input.GetAxis("Vertical");
        HorizontalAxis = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * MovementSpeed * VerticalAxis * Time.deltaTime);
        transform.Translate(Vector3.right * MovementSpeed * HorizontalAxis * Time.deltaTime);
    }

    private void HandleMouseLook() {
        // If you change the axis names, you need to change the arguments of the the GetAxis() calls below, again
        MouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.fixedUnscaledDeltaTime;
        MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.fixedUnscaledDeltaTime;

        XRot -= MouseY;
        XRot = Mathf.Clamp(XRot, -90f, 90f);
        YRot += MouseX;

        this.transform.rotation = Quaternion.Euler(0f, YRot, 0f);
        PlayerCam.transform.rotation = Quaternion.Euler(XRot, YRot, 0f);
    }

    private void FixedUpdate() {
        HandleMovement();
        HandleMouseLook();
    }
}
