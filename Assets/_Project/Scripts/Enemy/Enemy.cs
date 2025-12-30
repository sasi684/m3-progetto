using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    [SerializeField] private int _damage = 25;

    private EnemyManager _enemyManager;
    private EnemyAnimation _enemyAnimation;
    private PlayerController _player;

    void Awake()
    {
        _enemyManager = FindAnyObjectByType<EnemyManager>();
        if (!_enemyManager) Debug.LogError($"Nessun enemy manager rilevato per {name}");
        _enemyManager.AddEnemy(this);

        _enemyAnimation = GetComponent<EnemyAnimation>();
        if (!_enemyAnimation) Debug.LogError($"Per l'oggetto {name} non e' presente una componente EnemyAnimation");

        _player = FindAnyObjectByType<PlayerController>();
        if (!_player) Debug.LogError($"Nessun player rilevato nella scena per {name}");
    }

    void Start()
    {
        gameObject.SetActive(false); // Disable the enemy until the player picks up the gun
    }

    void Update()
    {
        if (_player)
        {
            MoveEnemy();
        }
    }

    private void MoveEnemy() // Function to move the enemy if there is a player in the scene
    {
        Vector3 movingDirection = (_player.transform.position - transform.position).normalized;
        _enemyAnimation.SetHorizontalSpeedParam(movingDirection.x);
        _enemyAnimation.SetVerticalSpeedParam(movingDirection.y);
        transform.position = transform.position + movingDirection * (_speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision) // If the enemy collides with the player, destroy the enemy and make damage
    {
        if (collision.collider.TryGetComponent<PlayerController>(out var player))
        {
            if(player.TryGetComponent<LifeController>(out var playerLifeController))
                playerLifeController.TakeDamage(_damage);

            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        _enemyManager.RemoveEnemy(this); // Remove the enemy from the list on death
    }
}
