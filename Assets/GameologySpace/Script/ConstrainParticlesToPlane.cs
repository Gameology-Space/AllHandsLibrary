using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ConstrainParticlesToPlane : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    private ParticleSystem.Particle[] _particles;

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _particles = new ParticleSystem.Particle[_particleSystem.main.maxParticles];
    }

    private void Update()
    {
        int numParticlesAlive = _particleSystem.GetParticles(_particles);

        for (int i = 0; i < numParticlesAlive; i++)
        {
            Vector3 position = _particles[i].position;
            position.y = 0.3f; // Constrain particles to the XZ plane
            _particles[i].position = position;
        }

        _particleSystem.SetParticles(_particles, numParticlesAlive);
    }
}
