using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f; // Variable used to adjust player's speed in the inspector

    private Rigidbody2D _rb;
    private PlayerAnimation _playerAnimation;

    private float _horizontal;
    private float _vertical;
    private Vector2 _direction;

    public Vector2 Direction { get => _direction; private set => Direction = value; } // Property used to get the player's moving direction if needed

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (!_rb) Debug.LogError($"Per l'oggetto {name} non e' presente una componente Rigidbody2D");

        _playerAnimation = GetComponent<PlayerAnimation>();
        if (!_playerAnimation) Debug.LogError($"Per l'oggetto {name} non e' presente una componente PlayerAnimation");
    }

    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        if(_horizontal != 0  || _vertical != 0) // If the player is moving, pass the values to the animator
        {
            _playerAnimation.SetHorizontalSpeedParam(_horizontal);
            _playerAnimation.SetVerticalSpeedParam(_vertical);
            _playerAnimation.SetIsMovingParam(true);
        }
        else
            _playerAnimation.SetIsMovingParam(false);
    }

    void FixedUpdate()
    {
        _direction = new Vector2(_horizontal, _vertical);
        if (_direction.sqrMagnitude > 1) _direction = _direction.normalized; // Normalize the direction vector in case of diagonal movement

        _rb.MovePosition(_rb.position + _direction * (_speed * Time.fixedDeltaTime));
    }
}
