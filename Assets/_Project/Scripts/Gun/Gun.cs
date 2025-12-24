using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _range;

    private EnemyManager _enemyManager;
    private float _lastShot = 0f;

    void Awake()
    {
        if(!_bulletPrefab) Debug.LogError($"Nessun prefab bullet asssegnato al gambeObject {name}");

        _enemyManager = FindAnyObjectByType<EnemyManager>();
        if(!_enemyManager) Debug.LogError($"Nessun enemy manager rilevato per {name}");
    }

    void Update()
    {
        if(Time.time - _lastShot >= _fireRate)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject nearestEnemy = FindNearestEnemy();
        if (nearestEnemy)
        {
            Bullet bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            Vector3 bulletDirection = (nearestEnemy.transform.position - transform.position).normalized;
            bullet.Direction = bulletDirection;

            _lastShot = Time.time;
        }
    }

    private GameObject FindNearestEnemy()
    {
        GameObject nearestEnemy = null;
        float minDistance = _range;

        foreach (var enemy in _enemyManager.GetEnemiesList())
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy.gameObject;
            }
        }

        return nearestEnemy;
    }
}
