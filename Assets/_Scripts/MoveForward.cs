using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
  [Tooltip("Velocidad de la bala en m/s")]
  [Range(0, 100)]
  public int velocidad;
  void Update()
  {
    transform.Translate(0, 0, velocidad * Time.deltaTime);
  }
}
