using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WavesUI : MonoBehaviour
{
    private TextMeshProUGUI _texto;

    private void Start() {
        _texto = GetComponent<TextMeshProUGUI>();
        WaveManager.SharedInstance.onWaveChanged.AddListener(RefrescarTexto);
        RefrescarTexto();
    }

    private void RefrescarTexto()
    {
        _texto.text = "Oleada " + 
        (WaveManager.SharedInstance.MaxWaves-WaveManager.SharedInstance.WavesCount) + 
        "/" + WaveManager.SharedInstance.MaxWaves;
    }
}
