using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFinishedParticles : MonoBehaviour {
    ParticleSystem thisParticle;
    void Start()
    {
        thisParticle = GetComponent<ParticleSystem>();
    }
	void Update ()
    {
        if (!thisParticle.isPlaying)
        {
            Destroy(gameObject);
        }
	}
}
