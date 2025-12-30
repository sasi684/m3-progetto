using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAnimation : MonoBehaviour
{
    [SerializeField] private string _colliderTriggerParamName = "hasCollided"; // Param name for the collision detection in the animator

    private Animator _bulletAnimator;

    void Awake()
    {
        _bulletAnimator = GetComponentInChildren<Animator>();
        if (!_bulletAnimator) Debug.LogError($"Nessuna componente Animator per l'oggetto {name}");
    }

    public void SetColliderTrigger() => _bulletAnimator.SetTrigger( _colliderTriggerParamName );
}
