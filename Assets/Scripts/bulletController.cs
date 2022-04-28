using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class bulletController : MonoBehaviour
{
    public float speed;
    // public GameObject EffectGameObject;
    public ParticleSystem HitEffect;

    void Start()
    {
        //Physics2D.IgnoreLayerCollision(6, 7, true);

        Destroy(gameObject, 10);
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public virtual void Collide(Collision collision)
    {
        Instantiate(HitEffect, transform.position, transform.rotation);
        HitEffect.Play(true);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collide(collision);
    }
}
