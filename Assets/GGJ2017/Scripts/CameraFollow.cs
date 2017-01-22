using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Rigidbody2D Rigid; 
	public BoxCollider2D ColliderDeSobrePaso;

	public Rigidbody2D RigidConejo;

	bool acelerated = false;

    void Start()
    {
		if(RigidConejo == null) throw new Exception("RigidConejo is not set");
        Rigid = gameObject.GetComponent<Rigidbody2D>();
		ColliderDeSobrePaso = gameObject.GetComponent<BoxCollider2D> ();
        Vector2 Velocidad = new Vector2(1f,0f);
        Rigid.velocity = Velocidad;
		acelerated = false;
    }

    void FixedUpdate()
    {
      if(acelerated) {
		  Vector3 position = transform.position;
		  position.x += 5 * RigidConejo.velocity.x * Time.fixedDeltaTime;
		  transform.position = position;
	  }
    }

	public void OnTriggerEnter2D(Collider2D ColliderObjetivo ){
		if (ColliderObjetivo.tag == "Player") {
			acelerated = true;
		}
	}

	public void OnTriggerExit2D(Collider2D ColliderObjetivo ){
		if(ColliderObjetivo.tag=="Player"){
			acelerated = false;	
		}
	}
}
