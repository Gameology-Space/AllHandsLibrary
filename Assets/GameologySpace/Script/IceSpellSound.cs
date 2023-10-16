using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class IceSpellSound : MonoBehaviour
{
    private ParticleSystem myparticleSystem;
    private ParticleSystem.Particle[] particles;

    private void Start()
    {
        myparticleSystem = GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[myparticleSystem.main.maxParticles];
    }

    private void Update()
    {
        int particleCount = myparticleSystem.GetParticles(particles);

        for (int i = 0; i < particleCount; i++)
        {
            // Check if the particle's remaining lifetime is at its maximum (just spawned)
            if (particles[i].remainingLifetime >= myparticleSystem.main.startLifetime.constant - Time.deltaTime)
            {
                SoundFX.Instance.PlayIceSound();
            }
        }
    }
}
