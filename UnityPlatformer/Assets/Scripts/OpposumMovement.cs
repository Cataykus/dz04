using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class OpposumMovement : MonoBehaviour
{
    [SerializeField] private Transform target1;
    [SerializeField] private Transform target2;
    [SerializeField] private float _runSpeed;

    private Rigidbody2D _opposumRigidbody;
    private SpriteRenderer _opposumSpriteRenderer;
    private Vector2 _target1Position;
    private Vector2 _target2Position;
    private Vector2 _direction;

    private void Start()
    {
        _opposumRigidbody = GetComponent<Rigidbody2D>();
        _opposumSpriteRenderer = GetComponent<SpriteRenderer>();
        _target1Position = target1.position;
        _target2Position = target2.position;
        _direction = Vector2.left;
    }

    private void Update()
    {
        if (Math.Round(transform.position.x, 1)   == _target1Position.x)
        {
            _direction = Vector2.right;
            _opposumSpriteRenderer.flipX = true;
        }
        else if (Math.Round(transform.position.x, 1) == _target2Position.x)
        {
            _direction = Vector2.left;
            _opposumSpriteRenderer.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        _opposumRigidbody.velocity = new Vector2(_direction.x * _runSpeed * Time.fixedDeltaTime * 100f, _opposumRigidbody.velocity.y);
    }
}
