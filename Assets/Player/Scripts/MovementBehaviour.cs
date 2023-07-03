using UnityEngine;

public partial class PlayerMovement : PlayerControl
{
    private void GetDirection()
    {
        _direction = PlayerInput.Player.Move.ReadValue<Vector2>();
    }

    private void Move()
    {
        _move = new Vector2(_direction.x, _direction.y);
        float scaledMoveSpeed = _speed * Time.fixedDeltaTime;

        _rigidbody2D.MovePosition(_rigidbody2D.position + _move * scaledMoveSpeed);
    }

    /// <summary>
    /// Implementation of simplified inertia, which is set depending on the 
    /// direction along the positive or negative Y axis
    /// </summary>
    private void SetInertia()
    {
        if (_direction.y > 0)
        {
            _rigidbody2D.gravityScale = -1;
        }
        else if (_direction.y < 0)
        {
            _rigidbody2D.gravityScale = 1;
        }
    }

    private void Rotate()
    {
        if (_direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(-_direction.x, _direction.y) * Mathf.Rad2Deg;
            _transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}