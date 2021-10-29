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

	private Rigidbody rb;

	void Start()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Confined;

		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		float distancia = velocidad * Time.deltaTime;

		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		Vector3 direccion = new Vector3(horizontal, 0, vertical);
		//transform.Translate(direccion.normalized * distancia);
		rb.AddRelativeForce(direccion.normalized * distancia);

		float angulo = rapidezRotacion * Time.deltaTime;
		float rotacion = Input.GetAxis("Rotar X");
		//transform.Rotate(0, rotacion * angulo, 0);
		rb.AddRelativeTorque(0, rotacion * angulo, 0);

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