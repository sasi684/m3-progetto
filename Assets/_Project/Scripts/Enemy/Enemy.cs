using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;

    private EnemyManager _enemyManager;

    void Awake()
    {
        _enemyManager = FindAnyObjectByType<EnemyManager>();
        if (!_enemyManager) Debug.LogError($"Nessun enemy manager rilevato per {name}");
        _enemyManager.AddEnemy(this);
    }

    void OnDestroy()
    {
        _enemyManager.RemoveEnemy(this);
    }
}
