using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f; // Variable used to adjust player's speed in the inspector

    private Rigidbody2D _rb;

    private float _horizontal;
    private float _vertical;
    private Vector2 _direction;

    public Vector2 Direction { get => _direction; private set => Direction = value; } // Property used to get the player's moving direction if needed

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
        if (_direction.sqrMagnitude > 1) _direction = _direction.normalized; // Normalize the direction vector in case of diagonal movement

        _rb.MovePosition(_rb.position + _direction * (_speed * Time.fixedDeltaTime));
    }
}
