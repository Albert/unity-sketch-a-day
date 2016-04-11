using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class April5Logic : MonoBehaviour
{
	private ParticleSystem m_System;
	private ParticleSystem.Particle[] m_Particles;
	private int numParticles = 300;

	void Start() {
		m_Particles = new ParticleSystem.Particle[numParticles];
		m_System = GetComponent<ParticleSystem>();
		m_System.SetParticles (m_Particles, numParticles);
	}

	private void LateUpdate()
	{
		for (int i = 0; i < numParticles; i++)
		{
			m_Particles [i].position = new Vector3 (i, i, i);
		}

		m_System.SetParticles(m_Particles, numParticles);
	}

}
