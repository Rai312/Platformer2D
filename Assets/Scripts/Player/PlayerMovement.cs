using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;
    private PlayerInput _playerInput;
    private Vector2 _direction;
    private bool _isGrounded;


    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
    }

    private void OnEnable()
    {
        _playerInput.Player.Jump.performed += ctx => Jump();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _direction = _playerInput.Player.Move.ReadValue<Vector2>();

        Move(_direction);
    }

    private void Move(Vector2 direction)
    {
        transform.Translate(direction.x * Time.deltaTime * _speed, 0, 0);
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _isGrounded = false;
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGrounded = true;
    }
}
