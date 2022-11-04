using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform Player;
    private Vector3 _offset = new Vector3(0, 0, -20);
    [SerializeField] private float _smoothSpeed = 0.1f;

    private Vector3 Velocity = Vector3.zero;

    void Start()
    {
        transform.position = Player.position;
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = Player.position + _offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref Velocity, _smoothSpeed);

        transform.position = smoothedPosition;
    }
}