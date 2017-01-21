using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Rigidbody2D Rigid; 
	public BoxCollider2D ColliderDeSobrePaso;

    void Start()
    {
        Rigid = gameObject.GetComponent<Rigidbody2D>();
		ColliderDeSobrePaso = gameObject.GetComponent<BoxCollider2D> ();
        Vector2 Velocidad = new Vector2(1f,0f);
        Rigid.velocity = Velocidad;
    }

    void Update()
    {
      
    }

	public void OnTriggerStay2D(Collider2D ColliderObjetivo ){
		if (ColliderObjetivo.tag == "Player") {
			Rigidbody2D RigidConejo = ColliderObjetivo.GetComponent<Rigidbody2D> ();
			Rigid.velocity = new Vector2 (RigidConejo.velocity.x, 0f);	
		}
	}

	public void OnTriggerExit2D(Collider2D ColliderObjetivo ){
			if(ColliderObjetivo.tag=="Player"){
				Rigidbody2D RigidConejo = ColliderObjetivo.GetComponent<Rigidbody2D> ();
				Rigid.velocity = new Vector2(1f,0f);	
		}

		
	}
}
