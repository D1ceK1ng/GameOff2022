using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public Transform Target;
    public Vector3 WanderPosition;
    [SerializeField] private protected float _speed = 1;
    [SerializeField] private protected float _damage = 3;
    [SerializeField] private protected Health _health;
    [SerializeField] private protected Rigidbody2D _rigidbody;
    protected IMovable _movable;

    public abstract IMovable Movable { get; }
    public abstract Health Health { get; }
    public abstract float Speed { get; set; }
    public abstract float Damage { get; set; }
    public abstract Rigidbody2D Rigidbody { get; set; }



    private void FixedUpdate()
    {
        _movable.Move();
    }
}



