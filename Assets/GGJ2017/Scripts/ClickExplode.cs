using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickExplode : MonoBehaviour {
	public  Transform PosicionDeLaBola;
	public Rigidbody2D RigBody;
	public float MultiplicadorDeFuerza;
	public float MagnitudDeExplosion;

	// Use this for initialization
	void Start () {
		PosicionDeLaBola = GetComponent<Transform>();
		RigBody = GetComponent<Rigidbody2D> ();
		
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			Vector2 VectorDeBolaHaPuntero =PosicionDeLaBola.position-Camera.main.ScreenToWorldPoint(Input.mousePosition);
			print (VectorDeBolaHaPuntero);
			RigBody.AddForce ((MultiplicadorDeFuerza/VectorDeBolaHaPuntero.magnitude)*VectorDeBolaHaPuntero);
			}
	}
}
