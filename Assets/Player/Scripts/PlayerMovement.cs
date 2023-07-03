using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public partial class PlayerMovement : PlayerControl
{
    [SerializeField] private float _speed;

    protected Rigidbody2D _rigidbody2D;
    protected Transform _transform;
    protected Vector2 _direction;
    protected Vector2 _move;

    public override void Awake()
    {
        base.Awake();

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();

        PlayerInput.Player.Move.performed += movementContext => GetDirection();
    }

    private void Start()
    {
        _rigidbody2D.gravityScale = -1;
        _speed = 7;
    }

    private void FixedUpdate()
    {
        GetDirection();
        SetInertia();
        Move();
        Rotate();
    }

    //public void movement()
    //{
    //    getdirection();
    //    setinertia();
    //    move();
    //    rotate();
    //}

}