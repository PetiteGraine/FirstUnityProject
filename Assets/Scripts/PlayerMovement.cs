using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private Transform _orientation;
    public float MoveSpeed = 10f;
    public float JumpForce = 12f;
    public float Gravity = -10f;
    public float ZoomSpeed = 2.0f;
    public float MinZoom = 20.0f;
    public float MaxZoom = 60.0f;
    private float _horizontal;
    private float _vertical;
    private Vector3 _moveDirection;
    private Vector3 _previousPosition;

    void Update()
    {
        Zoom();
        Move();
        Jump();
        Cam();
    }

    void Zoom()
    {
        _playerCamera.fieldOfView += Input.mouseScrollDelta.y * ZoomSpeed;
        _playerCamera.fieldOfView = Mathf.Clamp(_playerCamera.fieldOfView, MinZoom, MaxZoom);
    }

    void Move()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        _moveDirection = _orientation.forward * _vertical + _orientation.right * _horizontal;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && _characterController.isGrounded)
        {
            _moveDirection.y = JumpForce;
        }
        _moveDirection.y += Gravity * Time.deltaTime;
        _characterController.Move(_moveDirection * Time.deltaTime * MoveSpeed);
    }

    void Cam()
    {

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            _previousPosition = _playerCamera.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            Vector3 newPosition = _playerCamera.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = _previousPosition - newPosition;

            float rotationAroundYAxis = -direction.x * 180;
            float rotationAroundXAxis = direction.y * 180;

            _playerCamera.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
            _playerCamera.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World);

            _previousPosition = newPosition;
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 lookDirection = _playerCamera.transform.forward;
            lookDirection.y = 0;

            if (lookDirection != Vector3.zero)
            {
                _orientation.rotation = Quaternion.LookRotation(lookDirection);
            }
        }
        _playerCamera.transform.position = _orientation.position;
        _playerCamera.transform.Translate(new Vector3(0, 0, -10));
    }
}