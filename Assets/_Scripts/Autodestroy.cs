using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodestroy : MonoBehaviour
{
    [Tooltip("Tiempo después del cual se destruye el objeto")]
    public float tiempo;
    void OnEnable()
    {
        //Destroy(gameObject, tiempo);

        Invoke("OcultarObjeto", tiempo);
    }

    void OcultarObjeto()
    {
        gameObject.SetActive(false);
    }
}
