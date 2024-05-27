using UnityEngine;
using UnityEngine.InputSystem;

public class Particle : MonoBehaviour
{
    public ParticleSystem foamParticleSystem;
    public InputActionReference spawnAction;

    private void OnEnable()
    {
        spawnAction.action.started += OnSpawnStarted;
        spawnAction.action.canceled += OnSpawnCanceled;

        if (foamParticleSystem.isPlaying)
        {
            foamParticleSystem.Stop();
        }
    }

    private void OnDisable()
    {
        spawnAction.action.started -= OnSpawnStarted;
        spawnAction.action.canceled -= OnSpawnCanceled;
    }

    protected virtual void OnSpawnStarted(InputAction.CallbackContext context)
    {
        if (!foamParticleSystem.isPlaying)
        {
            foamParticleSystem.Play();
        }
    }

    protected virtual void OnSpawnCanceled(InputAction.CallbackContext context)
    {
        if (foamParticleSystem.isPlaying)
        {
            foamParticleSystem.Stop();
        }
    }
}
