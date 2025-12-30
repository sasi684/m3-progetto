using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip _startingTheme;
    [SerializeField] private AudioClip _fightingTheme;

    private AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        _audioSource.clip = _startingTheme;
        _audioSource.Play();
    }

    public void SwitchTheme()
    {
        _audioSource.Stop();
        _audioSource.clip = _fightingTheme;
        _audioSource.Play();
    }
}
