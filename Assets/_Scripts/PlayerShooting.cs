using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Tooltip("Prefab a disparar")]

    private Animator _animator;

    public int bulletsAmount;

    public Weapon arma;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button2) && Time.timeScale > 0)
        {
            _animator.SetBool("Shot Bullet Bol", true);

            if (bulletsAmount > 0 && arma.DispararBala("Bala Jugador", 0.2f))
            {
                bulletsAmount--;
                if (bulletsAmount < 0)
                {
                    bulletsAmount = 0;
                }
            }
        }
        else
        {
            _animator.SetBool("Shot Bullet Bol", false);
        }
    }
}
