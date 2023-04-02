using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle2DMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float speed;

    private void Start()
    {
        _rigidbody2D.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
    }

    // private void FixedUpdate()
    // {
    //     _rigidbody2D.AddForce(Vector2.right * (Time.deltaTime * speed), ForceMode2D.Force);
    // }
}
