using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField]
    private float cantidad;

    public float Cantidad
    {
        get => cantidad;
        set
        {
            cantidad = value;
            if (cantidad <= 0)
            {
                Animator anim = GetComponent<Animator>();
                anim.SetTrigger("Play Die");

                Invoke("PayDestruccion", 1);

                Destroy(gameObject, 2);
            }
        }
    }

    void PayDestruccion()
    {
        ParticleSystem explosion = GetComponentInChildren<ParticleSystem>();
        explosion.Play();
    }
}