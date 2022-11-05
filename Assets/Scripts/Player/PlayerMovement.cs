using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : IMovable
{
    private Rigidbody2D _rigidbody2D;
    private PlayerController _playerInput;
    private Vector2 _playerVector;
    public float Speed { get; set; }
    public Transform CurrentTransform { get; set; }

    public void Move()
    {
        _rigidbody2D.AddForce(_playerVector * Speed);
    }
    public PlayerMovement(Transform currentPoint, float speed, Rigidbody2D rigidbody2D)
    {
        CurrentTransform = currentPoint;
        _rigidbody2D = rigidbody2D;
        Speed = speed;
        _playerInput = new();
        _playerInput.PlayerInput.Movement.started += OnMove;
        _playerInput.PlayerInput.Movement.performed += OnMove;
        _playerInput.PlayerInput.Movement.canceled += OnMove;
        _playerInput.PlayerInput.Enable();
    }
    private void OnMove(InputAction.CallbackContext context)
    {
        _playerVector = context.ReadValue<Vector2>();
    }
}
