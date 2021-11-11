using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public int distancia;
    public int angulo;

    public LayerMask capasObjetivos;
    public LayerMask capasObstaculos;

    public Collider objetivoDetectado;

    private void Update()
    {
        Collider[] colisiones = Physics.OverlapSphere(transform.position, distancia, capasObjetivos);

        objetivoDetectado = null;

        foreach (Collider colision in colisiones)
        {
            Vector3 direccionDeColision = Vector3.Normalize(colision.bounds.center - transform.position);

            //Ángulo que forman el vector de visión con el vector objetivo
            float anguloDeColision = Vector3.Angle(transform.forward, direccionDeColision);

            //Si el ángulo de colisión es menor que el ángulo de visión
            if (anguloDeColision < angulo)
            {
                //Comprobamos que no hayan obstáculos en la línea de visión
                if (!Physics.Linecast(transform.position, colision.bounds.center, out RaycastHit hit, capasObstaculos))
                {
                    Debug.DrawLine(transform.position, colision.bounds.center, Color.green);

                    //Guardamos la referencia del objetivo detectado
                    objetivoDetectado = colision;
                    break;
                }
                else
                {
                    Debug.DrawLine(transform.position, hit.point, Color.magenta);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distancia);

        Vector3 derecho = Quaternion.Euler(0, angulo, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, derecho * distancia);
        Vector3 izquierdo = Quaternion.Euler(0, -angulo, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, izquierdo * distancia);
    }
}
