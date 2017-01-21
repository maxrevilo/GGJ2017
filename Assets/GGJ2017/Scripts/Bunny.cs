using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : MonoBehaviour {

	Animator animator;
	ClickExplode clickExplode;

	void Start () {
		animator = GetComponentInChildren<Animator>();
		clickExplode = GetComponent<ClickExplode>();

		clickExplode.OnDieEvent += DieEvent;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void DieEvent(GameObject gameObject) {
		animator.SetBool("isAlive", false);
	} 
}
