using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Vector3 _offset = new Vector3(0, 0, -20);
    [SerializeField] private float _smoothSpeed = 0.1f;

    private Vector3 Velocity = Vector3.zero;

    void Start()
    {
        transform.position = _player.position;
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = _player.position + _offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref Velocity, _smoothSpeed);

        transform.position = smoothedPosition;
    }
}