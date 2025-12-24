using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;

    private EnemyManager _enemyManager;
    private PlayerController _player;

    void Awake()
    {
        _enemyManager = FindAnyObjectByType<EnemyManager>();
        if (!_enemyManager) Debug.LogError($"Nessun enemy manager rilevato per {name}");
        _enemyManager.AddEnemy(this);

        _player = FindAnyObjectByType<PlayerController>();
        if (!_player) Debug.LogError($"Nessun player rilevato nella scena per {name}");
    }

    void Update()
    {
        if (_player)
        {
            MoveEnemy();
        }
    }

    private void MoveEnemy()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed *  Time.deltaTime);
    }

    void OnDestroy()
    {
        _enemyManager.RemoveEnemy(this);
    }
}
