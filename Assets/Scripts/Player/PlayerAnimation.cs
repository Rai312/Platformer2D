using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _renderer;
    private PlayerInput _playerInput;
    private Vector2 _direction;
    private const string IsRun = "IsRun";

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _direction = _playerInput.Player.Move.ReadValue<Vector2>();

        if (_direction.x < 0 || _direction.x > 0)
        {
            _animator.SetBool(IsRun, true);

            if (_direction.x < 0)
            {
                _renderer.flipX = true;
            }
            else if (_direction.x > 0)
            {
                _renderer.flipX = false;
            }
        }
        else
        {
            _animator.SetBool(IsRun, false);
        }
    }
}
