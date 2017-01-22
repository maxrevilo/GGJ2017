using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CargarJuego(){
		SceneManager.LoadScene("Nivel0");
	}

	public void CargarCreditos(){
		SceneManager.LoadScene("Creditos");
	}

	public void SalirJuego(){
		Application.Quit();
	}
}
