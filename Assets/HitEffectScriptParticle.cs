using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffectScriptParticle : MonoBehaviour
{
    public ParticleSystem HitParticle;

    void Start()
    {
        foreach (Transform child in transform.GetComponentsInChildren<Transform>())
        {
            HitParticle = child.GetComponent<ParticleSystem>();
            HitParticle.Play(true); 
        }
    }

    void Update()
    {
        
    }
}
