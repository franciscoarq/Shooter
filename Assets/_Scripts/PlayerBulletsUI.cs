using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBulletsUI : MonoBehaviour
{
    private TextMeshProUGUI _texto;

    public PlayerShooting targetShooting;

    private void Awake()
    {
        _texto = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _texto.text = "Balas: " + targetShooting.bulletsAmount;
    }
}
