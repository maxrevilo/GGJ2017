using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePod : MonoBehaviour {

	public ParticleSystem[] particles;
	public Animator animator;

	public CameraFollow cameraFollow;

	// Use this for initialization
	void Start () {
		animator = transform.GetChild(0).GetComponent<Animator>();
		if(cameraFollow == null) throw new Exception("cameraFollow not set");

		foreach(ParticleSystem ps in particles) {
			ps.gameObject.SetActive(false);
		}
	}
	
	void OnTriggerEnter2D(Collider2D ObjetoQueColiciono){
		string TagDelCollider = ObjetoQueColiciono.gameObject.tag;
		Debug.Log(ObjetoQueColiciono);
		if(TagDelCollider.Equals("Player")){
			ObjetoQueColiciono.gameObject.SetActive(false);
			animator.SetTrigger("escape");
			foreach(ParticleSystem ps in particles) {
				ps.gameObject.SetActive(true);
			}
			cameraFollow.Win();
		}
	}
}
