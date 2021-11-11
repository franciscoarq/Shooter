using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemiesUI : MonoBehaviour
{
    private TextMeshProUGUI _texto;

    private void Start() {
        _texto = GetComponent<TextMeshProUGUI>();
        EnemyManager.SharedInstance.onEnemyChanged.AddListener(RefrescarTexto);
        RefrescarTexto();
    }

    private void RefrescarTexto()
    {
        _texto.text = "Enemigos Restantes: " + EnemyManager.SharedInstance.EnemyCount;
    }
}
