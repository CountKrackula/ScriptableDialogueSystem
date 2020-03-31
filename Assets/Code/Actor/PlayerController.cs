using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : ActorController
{
    [Header("Components")]
    private Rigidbody m_Rigidbody;

    [Header("Input")]
    public KeyCode UseKey;
    public bool inputLocked;

    private float m_VerticalMovement;
    private float m_HorizontalMovement;

    public float MoveSpeed;
    public Vector3 MousePosition { get { return Camera.main.ScreenToWorldPoint(Input.mousePosition); } }

    public LayerMask AimLayerMask;

    [Header("Events")]
    public PlayerUseAction onUseKeyPressed;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        // When the tank is turned on, make sure it's not kinematic.
        m_Rigidbody.isKinematic = false;

        // Also reset the input values.
        m_VerticalMovement = 0f;
        m_HorizontalMovement = 0f;
    }
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        if (inputLocked)
        {
            return;
        }
        m_VerticalMovement = Input.GetAxis("Vertical");
        m_HorizontalMovement = Input.GetAxis("Horizontal");

        if (Input.GetKeyUp(UseKey))
        {
            onUseKeyPressed.Invoke();
        }
    }
    private void FixedUpdate()
    {
        // Adjust the rigidbodies position and orientation in FixedUpdate.
        Movement();
        LookAtMouse();
    }
    private void OnDisable()
    {
        // When the tank is turned off, set it to kinematic so it stops moving.
        m_Rigidbody.isKinematic = true;
    }
    private void Movement()
    {
        Vector3 inputVector = Vector3.zero;
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = 0f;
        inputVector.z = Input.GetAxis("Vertical");

        Vector3 moveVector = inputVector.normalized * Time.fixedDeltaTime * MoveSpeed;
        // Apply this movement to the rigidbody's position.
        m_Rigidbody.MovePosition(m_Rigidbody.position + moveVector);
    }
    private void LookAtMouse()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        camRay.origin += new Vector3(0, -1, 0);
        if (Physics.Raycast(camRay, out RaycastHit hit, 100f, AimLayerMask))
        {
            Vector3 playerToMouse = hit.point - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(playerToMouse);
            lookRotation.x = 0f;
            lookRotation.z = 0f;
            transform.rotation = lookRotation;
        }
    }
}
