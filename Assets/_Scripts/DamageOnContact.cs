using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnContact : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter(Collider other) 
    {
        gameObject.SetActive(false);

        Life vida = other.GetComponent<Life>();

        if (vida != null)
        {
            vida.Cantidad -= damage;
        }

        /* if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        } */
    }
}