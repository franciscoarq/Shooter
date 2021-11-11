using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("Puntos que se obtienen al derrotar al enemigo")]
    public int cantidadDePuntos = 10;

    private void Awake()
    {
        var life = GetComponent<Life>(); //var puede ser Life
        life.onDeath.AddListener(DestroyEnemy);
    }

    private void Start()
    {
        EnemyManager.SharedInstance.AddEnemy(this);
    }

    private void DestroyEnemy()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("Play Die");

        Invoke("PayDestruccion", 1);

        var life = GetComponent<Life>();
        life.onDeath.RemoveListener(DestroyEnemy);

        Destroy(gameObject, 2);

        EnemyManager.SharedInstance.RemoveEnemy(this);
        ScoreManager.SharedInstance.Cantidad += cantidadDePuntos;
    }

    void PayDestruccion()
    {
        ParticleSystem explosion = GetComponentInChildren<ParticleSystem>();
        explosion.Play();
    }
}
