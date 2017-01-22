using System;
using UnityEngine;

public class WaveGraphics : MonoBehaviour {

    public GameObject distortionWave;

    public ParticleSystem particleSystem;

    public float maxDistortionStrenght = 40f;
    public float minDistortionStrenght = 5f;

    public float minParticleSize = .3f;
    public float maxParticleSize = .5f;

    public float minParticleSpeed = 2;
    public float maxParticleSpeed = 6;

    public Color minParticleColor = new Color();
    public Color maxParticleColor = new Color();

	void Start () {
        if(distortionWave == null) throw new Exception("distortionWave is not set");
        if(particleSystem == null) throw new Exception("particleSystem is not set");
	}
	
    // str = (0, 1]
    public void PlayWithStrenght(float str) {
        distortionWave.GetComponent<Renderer>().material.SetFloat(
            "MaxDistortion",
            Mathf.Lerp(minDistortionStrenght, maxDistortionStrenght, str)
        );

        ParticleSystem.MainModule main = particleSystem.main;

        main.startSize = Mathf.Lerp(minParticleSize, maxParticleSize, str);
        main.startSpeed = Mathf.Lerp(minParticleSpeed, maxParticleSpeed, str);
        main.startColor = Color.Lerp(minParticleColor, maxParticleColor, str);
    }
}
