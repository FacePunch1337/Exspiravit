using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starfield : MonoBehaviour
{
    private ParticleSystem particleSystem;
    public int particleCount = 300;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        var mainModule = particleSystem.main;
        mainModule.maxParticles = particleCount;
        particleSystem.Emit(particleCount);
    }
}
