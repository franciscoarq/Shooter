using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [Tooltip("Prefab de enemigo a generar")]
    public GameObject prefab;

    [Tooltip("Tiempo en el que se inicia y termina la oleada")]
    public float startTime, endTime;

    [Tooltip("Tiempo entre la generación de enemigos")]
    public float spawnRate;


    void Start()
    {
        WaveManager.SharedInstance.AddWave(this);
        InvokeRepeating("spawnEnemy", startTime, spawnRate);
        Invoke("EndWave", endTime);
    }

    void spawnEnemy()
    {
        /* Quaternion q = Quaternion.Euler(0, transform.rotation.eulerAngles.y + Random.Range(-45, 45), 0); */
        Instantiate(prefab, transform.position, transform.rotation);
    }

    void EndWave()
    {
        WaveManager.SharedInstance.RemoveWave(this);
        CancelInvoke();
    }
}
