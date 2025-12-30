using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private Gun _gunPrefab;

    private AudioManager _audioManager;

    void Awake()
    {
        _audioManager = FindObjectOfType<AudioManager>();
    }

    // Enable enemies on pickup, instantiate gun on player and play the fighting theme
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<PlayerController>(out var player))
            Instantiate(_gunPrefab, player.transform);

        EnemyManager.CanEnemiesSpawn = true;

        _audioManager.SwitchTheme();

        Destroy(gameObject);
    }
}
