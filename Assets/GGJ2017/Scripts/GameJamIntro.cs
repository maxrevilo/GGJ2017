using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameJamIntro : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("CargarJuego",5f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CargarJuego(){
		SceneManager.LoadScene("MainMenu");
	}
}
