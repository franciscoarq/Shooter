using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
  [Tooltip("Prefab a disparar")]

  public GameObject shootingPoint;

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Joystick1Button2))
    {
      GameObject bala = ObjectPool.InstanciaCompartida.PrimeraBalaEnPiscina();
      bala.layer = LayerMask.NameToLayer("Bala Jugador");
      bala.transform.position = shootingPoint.transform.position;
      bala.transform.rotation = shootingPoint.transform.rotation;
      bala.SetActive(true);
    }
  }
}
