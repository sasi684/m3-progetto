using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private Gun _gunPrefab;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<PlayerController>(out var player))
            Instantiate(_gunPrefab, player.transform);

        Destroy(gameObject);
    }
}
