using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    [SerializeField]
    private float cantidad;

    public float maximumLife = 100.0f;

    public UnityEvent onDeath;

    public float Cantidad
    {
        get => cantidad;
        set
        {
            cantidad = value;
            if (cantidad <= 0)
            {
                onDeath.Invoke();
            }
        }
    }

    private void Awake()
    {
        cantidad = maximumLife;
    }
}
