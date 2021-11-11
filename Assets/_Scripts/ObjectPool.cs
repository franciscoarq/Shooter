using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;

    public GameObject prefab;

    public List<GameObject> piscina;

    public int cantidad;

    void Awake(){
        if (SharedInstance == null)
        {
            SharedInstance = this;
        }
        else
        {
            Debug.LogError("Ya existe otra piscina");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        piscina = new List<GameObject>();
        GameObject objeto;

        for (int i = 0; i < cantidad; i++)
        {
            objeto = Instantiate(prefab);
            objeto.SetActive(false);
            piscina.Add(objeto);
        }
    }

    public GameObject PrimeraBalaEnPiscina()
    {
        for (int i = 0; i < cantidad; i++)
        {
            if (!piscina[i].activeInHierarchy)
            {
                return piscina[i];
            }
        }
        return null;
    }
}
