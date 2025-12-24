using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> _enemiesList;

    public void AddEnemy(Enemy enemy) => _enemiesList.Add(enemy);
    public void RemoveEnemy(Enemy enemy) => _enemiesList.Remove(enemy);
}
