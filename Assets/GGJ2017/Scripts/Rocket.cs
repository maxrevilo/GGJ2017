using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponentInChildren<Animator>();
	}
	
	void OnTriggerEnter2D(Collider2D ObjetoQueColiciono){
		string TagDelCollider = ObjetoQueColiciono.gameObject.tag;
		Debug.Log(ObjetoQueColiciono);
		if(TagDelCollider.Equals("Player")){
			animator.SetTrigger("Go");
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
