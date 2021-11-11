using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float ultimoDisparo;

    public float ratioDisparo;

    public GameObject shootingPoint;

    public ParticleSystem fireEffect;

    public AudioSource shootSound;

    private string layerName;

    public bool DispararBala(string layerName, float retraso)
    {
        if (Time.time > 0)
        {
            var tiempoDesdeUltimoDisparo = Time.time - ultimoDisparo;
            if (tiempoDesdeUltimoDisparo < ratioDisparo)
            {
                return false;
            }

            ultimoDisparo = Time.time;
            this.layerName = layerName;
            Invoke("FireBullet", retraso);

            return true;
        }

        return false;
    }

    void FireBullet()
    {
        var bala = ObjectPool.SharedInstance.PrimeraBalaEnPiscina();
            bala.layer = LayerMask.NameToLayer(layerName);
            bala.transform.position = shootingPoint.transform.position;
            bala.transform.rotation = shootingPoint.transform.rotation;
            bala.SetActive(true);

            if (fireEffect != null)
            {
                fireEffect.Play();
            }

            if (shootSound != null)
            {
                Instantiate(shootSound, transform.position, transform.rotation).GetComponent<AudioSource>().Play();
            }
    }
}
