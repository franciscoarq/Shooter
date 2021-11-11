using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
	[Tooltip("Fuerza de movimiento del personaje en N/s")]
	[Range(0, 1000)] //Newtons
	public int velocidad;

	[Tooltip("Fuerza de rotación del personaje en N/seg")]
	[Range(0, 360)]
	public int rapidezRotacion;

	private Rigidbody _rb;

	private Animator _animator;

	void Start()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Confined;

		_rb = GetComponent<Rigidbody>();
		_animator = GetComponent<Animator>();
	}

	void Update()
	{
		float espacio = velocidad * Time.deltaTime;

		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		Vector3 direccion = new Vector3(horizontal, 0, vertical);
		//transform.Translate(direccion.normalized * distancia);
		_rb.AddRelativeForce(direccion.normalized * espacio);

		float angulo = rapidezRotacion * Time.deltaTime;
		float rotacion = Input.GetAxis("Rotar X");
		//transform.Rotate(0, rotacion * angulo, 0);
		_rb.AddRelativeTorque(0, rotacion * angulo, 0);

		_animator.SetFloat("Velocidad", _rb.velocity.magnitude);

		/* _animator.SetFloat("MoverX", horizontal);
		_animator.SetFloat("MoverY", vertical);

		if (Input.GetKey(KeyCode.RightShift))
		{
			_animator.SetFloat("Velocidad", _rb.velocity.magnitude);
		}
		else
		{
			if (Mathf.Abs(horizontal) < 0.01f && Mathf.Abs(vertical) < 0.01f)
			{
				_animator.SetFloat("Velocidad", 0);
			}
			else
			{
				_animator.SetFloat("Velocidad", 0.15f);
			}
		} */

		/* if (Input.GetKey(KeyCode.UpArrow))
		{
		transform.Translate(0, 0, distancia);
		} else if (Input.GetKey(KeyCode.DownArrow))
		{
		transform.Translate(0, 0, -distancia);
		} else if (Input.GetKey(KeyCode.RightArrow))
		{
		transform.Translate(distancia, 0, 0);
		} else if (Input.GetKey(KeyCode.LeftArrow))
		{
		transform.Translate(-distancia, 0, 0);
		} */
	}
}