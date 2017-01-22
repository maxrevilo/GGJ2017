using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnCollide : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D ObjetoQueColiciono){
		gameObject.SetActive(false);
	}
}
