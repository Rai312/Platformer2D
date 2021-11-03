using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PatrolEnemy : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currentPoint;
    private SpriteRenderer _renderer;
    private float _negativeDirectionX = -0.5f;
    private float _positiveDirectionX = 0.5f;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];

        var direction = (target.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            ChangeDirectionAnimation(direction);
            _currentPoint++;
            
            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }

    private void ChangeDirectionAnimation(Vector2 direction)
    {
        if (direction.x > _positiveDirectionX)
        {
            _renderer.flipX = true;
        }
        else if (direction.x < _negativeDirectionX)
        {
            _renderer.flipX = false;
        }
    }
}
