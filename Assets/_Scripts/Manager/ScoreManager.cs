using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager SharedInstance;

    [SerializeField]
    [Tooltip("Cantidad de puntos de la partida")]
    private int cantidad;

    public int Cantidad
    {
        get => cantidad;
        set => cantidad = value;
    }

    private void Awake() {
        if (SharedInstance == null)
        {
            SharedInstance = this;
        }
        else
        {
            Debug.LogWarning("ScoreManager debe ser destruído", gameObject);
            Destroy(gameObject);
        }
    }
}

