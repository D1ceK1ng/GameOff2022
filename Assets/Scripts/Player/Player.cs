using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private PlayerHealth _playerHealth;

    private IMovable _playerMovement;
    private void Awake()
    {
        _playerMovement = new PlayerMovement( transform,_speed, _rigidbody2D);

        _playerHealth = new PlayerHealth();
    }

    

    private void FixedUpdate()
    {
        _playerMovement.Move();
    }
   
}
