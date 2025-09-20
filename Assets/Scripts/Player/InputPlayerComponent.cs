using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody), typeof(PlayerInput))]
public class InputPlayerComponent : MonoBehaviour


{
    [SerializeField] private float playerSpeed = 3.0f;
    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float rotationSpeed = 10.0f;
    private Vector3 playerVelocity = Vector3.zero;
    private bool groundedPlayer = false;

    [SerializeField] private SwitchAimCamera switchAimCamera;


    private Rigidbody rb;
    private Transform cameraTransform;
    private UIManagerComponent uiManager;

    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction InventoryAction;
    private InputAction jumpAction;
    private InputAction aimAction;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        uiManager = GetComponent<UIManagerComponent>();
        playerInput = GetComponent<PlayerInput>();

        cameraTransform = Camera.main.transform;


        moveAction = playerInput.actions["Move"];
        aimAction = playerInput.actions["Aim"];
    }

    private void Start()
    {

    }
    private void OnEnable()
    {
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => CancelAim();

    }

    private void OnDisable()
    {
        aimAction.performed -= _ => StartAim();
        aimAction.canceled -= _ => CancelAim();


    }

    private void StartAim()
    {
        switchAimCamera.AimCameraEnabled();
        uiManager.ShowCanvas(CanvasType.AimCanvas);
    }

    private void CancelAim()
    {
        switchAimCamera.AimCameraDisabled();
        uiManager.ShowCanvas(CanvasType.BaseCanvas);
    }




    void Update()
    {
        // groundedPlayer = controller.isGrounded;
        /* if (groundedPlayer && playerVelocity.y < 0)
         {
             playerVelocity.y = 0f;
         }*/

        // Read input
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 movement = new Vector3(input.x, 0, input.y).normalized;
        movement = movement.x * cameraTransform.right.normalized + movement.z * cameraTransform.forward.normalized;
        movement.y = 0f;
        rb.velocity = movement * playerSpeed;

        float targetAngle = cameraTransform.eulerAngles.y;
        Quaternion targetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Jump
        /* if (jumpAction.action.triggered && groundedPlayer)
         {
             playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
         }

         // Apply gravity
         playerVelocity.y += gravityValue * Time.deltaTime;

         // Combine horizontal and vertical movement
         Vector3 finalMove = (movement * playerSpeed) + (playerVelocity.y * Vector3.up);
         controller.Move(finalMove * Time.deltaTime);*/
    }
}


