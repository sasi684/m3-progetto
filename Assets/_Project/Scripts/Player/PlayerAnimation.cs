using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private string _horizontalSpeedParamName = "hSpeed";
    [SerializeField] private string _verticalSpeedParamName = "vSpeed";
    [SerializeField] private string _isMovingParamName = "isMoving";

    private Animator _playerAnimator;

    void Awake()
    {
        _playerAnimator = GetComponentInChildren<Animator>();
        if (!_playerAnimator) Debug.LogError($"Nessuna componente Animator per l'oggetto {name}");
    }

    public void SetHorizontalSpeedParam(float hSpeed) => _playerAnimator.SetFloat(_horizontalSpeedParamName, hSpeed);

    public void SetVerticalSpeedParam(float vSpeed) => _playerAnimator.SetFloat(_verticalSpeedParamName, vSpeed);

    public void SetIsMovingParam(bool isMoving) => _playerAnimator.SetBool(_isMovingParamName, isMoving);
}
