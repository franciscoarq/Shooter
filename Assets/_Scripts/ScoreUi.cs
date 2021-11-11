using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUi : MonoBehaviour
{
    private TextMeshProUGUI _texto;

    private void Awake()
    {
        _texto = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        _texto.text = "Puntaje: " + ScoreManager.SharedInstance.Cantidad;
    }
}
