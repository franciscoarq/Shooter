using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuadrosPorSegundo : MonoBehaviour {

  public int target = 30;

  void Awake()
  {
    #if UNITY_EDITOR
      QualitySettings.vSyncCount = 0;  // VSync must be disabled
      Application.targetFrameRate = target;
    #endif
  }

  void Update()
  {
    if (Application.targetFrameRate != target)
      Application.targetFrameRate = target;
  }
}
