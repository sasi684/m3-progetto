using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private Rigidbody2D _rb;

    private float _horizontal;
    private float _vertical;
    private Vector2 _direction;

    public Vector2 Direction { get => _direction; private set => Direction = value; }

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (!_rb) Debug.LogError($"Per l'oggetto {name} non e' presente una componente Rigidbody2D");
    }

    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        _direction = new Vector2(_horizontal, _vertical);
        if (_direction.sqrMagnitude > 1) _direction = _direction.normalized;

        _rb.MovePosition(_rb.position + _direction * (_speed * Time.fixedDeltaTime));
    }
}
