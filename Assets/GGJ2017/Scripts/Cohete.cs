using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cohete : MonoBehaviour {

	Animator animator;

	GameObject objective;

	public GameObject cohete;

	public float rotationSpeedDeg = 20;

	// Use this for initialization
	void Start () {
		if(cohete == null) throw new Exception("cohete not set");
		cohete.SetActive(false);
	}
	
	void OnTriggerEnter2D(Collider2D ObjetoQueColiciono){
		string TagDelCollider = ObjetoQueColiciono.gameObject.tag;
		Debug.Log(ObjetoQueColiciono);
		if(TagDelCollider.Equals("Player")){
			objective = ObjetoQueColiciono.gameObject;
			cohete.SetActive(true);
			cohete.GetComponent<Rigidbody2D>().velocity = cohete.transform.right * 10f;
			Invoke("Expire", 4);
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		RotateTowardObjective(rotationSpeedDeg * Time.fixedDeltaTime);
	}

	void RotateTowardObjective(float angSpeed = 9999999f) {
		if(objective != null) {
			Vector3 rightVec = objective.transform.position - cohete.transform.position;
			float rot_z = Mathf.Atan2(rightVec.y, rightVec.x) * Mathf.Rad2Deg;
         	Quaternion lookAtRotation = Quaternion.Euler(0f, 0f, rot_z);

			cohete.transform.rotation = Quaternion.RotateTowards(
				cohete.transform.rotation, lookAtRotation,
				angSpeed
				);
		}
	}

	void Expire() {
		Destroy(gameObject);
	}


}
