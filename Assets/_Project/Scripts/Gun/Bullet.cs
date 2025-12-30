using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 8f; // Variable used to adjust bullet's speed in the inspector
    [SerializeField] private float _bulletLifeSpan = 5f; // Variable used to adjust bullet's duration in the inspector
    [SerializeField] private int _damage = 20; // Variable used to adjust bullet's damage in the inspector

    private Vector2 _direction;
    public Vector2 Direction { get => _direction; set => _direction = value; } // This property will be used to set the direction when a bullet is instantiated

    private BulletAnimation _bulletAnimation;
    private Collider2D _collider;

    void Awake()
    {
        _bulletAnimation = GetComponent<BulletAnimation>();
        _collider = GetComponent<Collider2D>();
    }

    void Start()
    {
        Destroy(gameObject, _bulletLifeSpan); // Destroy the bullet after _bulletLifeSpan seconds after it's been instantiated
    }

    void Update()
    {
        transform.position = transform.position + (Vector3)_direction * (_speed * Time.deltaTime); // Move the bullet at each frame following the starting direction
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<LifeController>(out var life)) // If the collider has a LifeController component, inflict damage
            life.TakeDamage(_damage);

        _bulletAnimation.SetColliderTrigger();
        _direction = Vector2.zero;
        _collider.enabled = false;
        Destroy(gameObject, 0.5f); // Destroy the bullet after impact with any Collider (Enemy, wall, obstacle etc.)
    }
}
