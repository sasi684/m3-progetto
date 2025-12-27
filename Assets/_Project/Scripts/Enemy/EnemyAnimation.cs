using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private string _horizontalSpeedParamName = "hSpeed";
    [SerializeField] private string _verticalSpeedParamName = "vSpeed";

    private Animator _enemyAnimator;

    void Awake()
    {
        _enemyAnimator = GetComponentInChildren<Animator>();
        if (!_enemyAnimator) Debug.LogError($"Nessuna componente Animator per l'oggetto {name}");
    }

    public void SetHorizontalSpeedParam(float hSpeed) => _enemyAnimator.SetFloat(_horizontalSpeedParamName, hSpeed);

    public void SetVerticalSpeedParam(float vSpeed) => _enemyAnimator.SetFloat(_verticalSpeedParamName, vSpeed);
}
