using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _maxHp; // Max HP adjustable from the inspector

    private int _currentHp; // Current HP of the object

    void Start()
    {
        _currentHp = _maxHp; // Initialize the HP at the _maxHp
    }

    public void SetHp(int hp) // Set the HP and destroy the object if it goes at or below 0
    {
        _currentHp = hp;
        if (_currentHp <= 0 ) Destroy(gameObject);
    }

    public void AddHp(int amount) => SetHp(_currentHp + amount); // Add HP to the current HP
    public void TakeDamage(int damage) => SetHp(_currentHp - damage); // Subtract HP to the current HP
}
