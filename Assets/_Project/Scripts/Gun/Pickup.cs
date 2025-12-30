using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private Gun _gunPrefab;

    // Enable enemies on pickup and instantiate gun on player
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<PlayerController>(out var player))
            Instantiate(_gunPrefab, player.transform);

        EnemyManager.CanEnemiesSpawn = true;

        Destroy(gameObject);
    }
}
