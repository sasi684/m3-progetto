using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab; // Prefab for the bullet shot
    [SerializeField] private float _fireRate; // How many bullets shot each second
    [SerializeField] private float _range; // How far can enemies be spotted

    private EnemyManager _enemyManager; // The list of enemies is used in here
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

    private void Shoot() // Function to shoot the nearest enemy instantiating the bullet and giving it a direction
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

    private GameObject FindNearestEnemy() // Function to find the nearest enemy in range using the list provided by the enemy manager
    {
        GameObject nearestEnemy = null;
        float minDistance = _range;

        foreach (var enemy in _enemyManager.EnemiesList)
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
