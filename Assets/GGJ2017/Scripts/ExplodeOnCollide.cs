using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnCollide : MonoBehaviour {

	public GameObject explosionPrefab;

	void OnCollisionEnter2D(Collision2D ObjetoQueColiciono){
		if(explosionPrefab != null) {
			Instantiate(explosionPrefab, transform.position, transform.rotation, transform.parent);
		}
		gameObject.SetActive(false);
	}
}
