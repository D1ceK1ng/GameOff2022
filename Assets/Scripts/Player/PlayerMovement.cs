using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool CanMove = true;

    private Rigidbody2D _rigidBody;

    private float _horizontal, _vertical;

    //Limits diagnol movement
    private float _moveLimiter = 0.7f;

    public float MoveSpeed;


    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerInput();
    }

    void FixedUpdate()
    {
        Movement();
    }







    private void PlayerInput()
    {
        // Gives a value between -1 and 1
        _horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        _vertical = Input.GetAxisRaw("Vertical"); // -1 is down
    }


    private void Movement()
    {
        if (CanMove)
        {
            if (_horizontal != 0 && _vertical != 0) // Check for diagonal movement
            {
                // limit movement speed diagonally, so you move at 70% speed
                _horizontal *= _moveLimiter;
                _vertical *= _moveLimiter;
            }

            Vector2 newVel = new Vector2(_horizontal * MoveSpeed, _vertical * MoveSpeed);

            if (newVel != Vector2.zero)
            {
                _rigidBody.AddForce(newVel);
            }
        }
    }
}