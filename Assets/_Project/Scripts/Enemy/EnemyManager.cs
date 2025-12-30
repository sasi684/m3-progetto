using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> EnemiesList; // This list will contain each enemy initialized in the scene

    public static bool CanEnemiesSpawn = false;
    private bool _enemiesSpawned = false;

    void Update() // Activate the enemies only once when the player picks up the gun
    {
        if (CanEnemiesSpawn && !_enemiesSpawned)
        {
            ActivateEnemies();
        }
    }

    private void ActivateEnemies() // Function to activate all the enemies in the list
    {
        foreach (var enemy in EnemiesList)
        {
            enemy.gameObject.SetActive(true);
        }
        _enemiesSpawned = true;
    }

    public void AddEnemy(Enemy enemy) => EnemiesList.Add(enemy);
    public void RemoveEnemy(Enemy enemy) => EnemiesList.Remove(enemy);
}
