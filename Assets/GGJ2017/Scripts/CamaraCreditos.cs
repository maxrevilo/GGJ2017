using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamaraCreditos : MonoBehaviour {
	private Rigidbody2D RigidCamara;
	private BoxCollider2D Collider;

	// Use this for initialization
	void Start () {
		RigidCamara = gameObject.GetComponent<Rigidbody2D> ();
		Collider = gameObject.GetComponent<BoxCollider2D> ();
		RigidCamara.velocity = new Vector2 (2f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		SceneManager.LoadScene("MainMenu");
	}
}
