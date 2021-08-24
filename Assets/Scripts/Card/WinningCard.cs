using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class WinningCard : Card
{
    private ParticleSystem _particleSystem;
    

    private void Awake() => _particleSystem = GetComponent<ParticleSystem>();

    public override async void Interact()
    {
        if (_isInteractable)
        {
            SetInteractable(false);
            _particleSystem.Play();
            await _particleSystem.AsyncWaitForCompletion();
            _level.StartNextLevel();
        }
    }

}
