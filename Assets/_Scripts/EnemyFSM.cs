using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Sight))]
public class EnemyFSM : MonoBehaviour
{
    public enum EstadosDelEnemigo { IrHaciaBase, AtacaBase, PerseguirJugador, AtacarJugador }

    public EstadosDelEnemigo estadoActual;

    private Sight _sight;

    private Transform baseTransform;

    public float distanciaAtaqueBase, distanciaAtaqueJugador;

    private NavMeshAgent agente;

    private Animator animator;

    public Weapon arma;

    private void Awake()
    {
        _sight = GetComponent<Sight>();
        baseTransform = GameObject.FindWithTag("Base").transform;
        agente = GetComponentInParent<NavMeshAgent>();
        animator = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        switch (estadoActual)
        {
            case EstadosDelEnemigo.IrHaciaBase:
                IrHaciaBase();
                break;

            case EstadosDelEnemigo.AtacaBase:
                AtacaBase();
                break;

            case EstadosDelEnemigo.PerseguirJugador:
                PerseguirJugador();
                break;

            case EstadosDelEnemigo.AtacarJugador:
                AtacarJugador();
                break;

            default:
                //
            break;
        }
    }

    void IrHaciaBase()
    {
        //print("Ir a base");
        animator.SetBool("Shot Bullet Bool", false);

        agente.isStopped = false;
        agente.SetDestination(baseTransform.position);

        if (_sight.objetivoDetectado != null)
        {
            estadoActual = EstadosDelEnemigo.PerseguirJugador;
        }

        float distanciaHaciaBase = Vector3.Distance(transform.position, baseTransform.position);
        if (distanciaHaciaBase < distanciaAtaqueBase)
        {
            estadoActual = EstadosDelEnemigo.AtacaBase;
        }
    }

    void AtacaBase()
    {
        //print("Atacar base");
        agente.isStopped = true;

        Mirar(baseTransform.position);
        DispararObjetivo();
    }

    void PerseguirJugador()
    {
        //print("Perseguir jugador");
        animator.SetBool("Shot Bullet Bool", false);

        if (_sight.objetivoDetectado == null)
        {
            estadoActual = EstadosDelEnemigo.IrHaciaBase;
            return;
        }

        agente.isStopped = false;
        agente.SetDestination(_sight.objetivoDetectado.transform.position);

        float distanciaHaciaJugador = Vector3.Distance(transform.position, _sight.objetivoDetectado.transform.position);
        if (distanciaHaciaJugador < distanciaAtaqueJugador)
        {
            estadoActual = EstadosDelEnemigo.AtacarJugador;
        }
    }

    void AtacarJugador()
    {
        //print("Atacar jugador");
        agente.isStopped = true;

        Mirar(_sight.objetivoDetectado.transform.position);
        DispararObjetivo();

        if (_sight.objetivoDetectado == null)
        {
            estadoActual = EstadosDelEnemigo.IrHaciaBase;
            return;
        }

        float distancisHaciaJugador = Vector3.Distance(transform.position, _sight.objetivoDetectado.transform.position);
        if (distancisHaciaJugador > distanciaAtaqueJugador*1.1f)
        {
            estadoActual = EstadosDelEnemigo.PerseguirJugador;
        }
    }

    void DispararObjetivo()
    {
        if (arma.DispararBala("Bala Enemigo", 0))
        {
            animator.SetBool("Shot Bullet Bool", true);
        }
        

        /* if (Time.time > 0)
        {
            var tiempoDesdeUltimoDisparo = Time.time - ultimoDisparo;
            if (tiempoDesdeUltimoDisparo < ratioDisparo)
            {
                return;
            }

            
            ultimoDisparo = Time.time;
            var bala = ObjectPool.SharedInstance.PrimeraBalaEnPiscina();
            bala.layer = LayerMask.NameToLayer("Bala Enemigo");
            bala.transform.position = shootingPoint.transform.position;
            bala.transform.rotation = shootingPoint.transform.rotation;
            bala.SetActive(true);
        } */
    }

    void Mirar(Vector3 objetivo)
    {
        Vector3 direccion = Vector3.Normalize(objetivo - transform.position);
        direccion.y = 0;
        transform.parent.forward = direccion;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, distanciaAtaqueJugador);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, distanciaAtaqueBase);
    }
}
