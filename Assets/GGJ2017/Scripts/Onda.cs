using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onda : MonoBehaviour {
	public float TiempoAntesDeDestruir;
	public float RadioDeOnda;
	public bool Atraer;
	public float FuerzaDeOnda;
	public float RadioInicial;
	public float MaximoRadio = 2.5f;
	public CircleCollider2D ColisionadorDelObjeto;

	public float tiempoDeVida = 1.2f;

	// Use this for initialization
	void Start () {
		RadioInicial = 0;
	}
	
	// Update is called once per frame
	void Update () {
		AmpliarRadio ();
	}

	public void destruirOnda(){
		Destroy (gameObject);
	}

	public void setRadioDeOnda(float RadioDeOnda){
		this.RadioDeOnda = RadioDeOnda;
	}

	public void SetFuerzaDeOnda (float FuerzaDeOnda){
		this.FuerzaDeOnda = FuerzaDeOnda;
	}

	public void AmpliarRadio(){
		if(ColisionadorDelObjeto.radius <= MaximoRadio){
			ColisionadorDelObjeto.radius += 0.15f;
		}
	}

	void OnTriggerEnter2D(Collider2D ColiderObjetivo){
		if(ColiderObjetivo.CompareTag("Player")){
			print ("Te golpeo una onda");
			Vector2 PosicionDeLaOnda =  gameObject.transform.position;
			Vector2 PosicionDelObjeto = ColiderObjetivo.transform.position;
			Vector2 VectorOndaHaObjeto = Atraer ?  PosicionDeLaOnda - PosicionDelObjeto:PosicionDelObjeto - PosicionDeLaOnda  ;
			Rigidbody2D RigidBodyObjetivo = ColiderObjetivo.gameObject.GetComponent<Rigidbody2D> ();
			RigidBodyObjetivo.AddForce ((FuerzaDeOnda/VectorOndaHaObjeto.magnitude)*VectorOndaHaObjeto);
		}
	}

	public void DestruirOnda(){
		Invoke("destruirOnda",tiempoDeVida);
	}

	public void setAtraer(bool Atraer){
		this.Atraer = Atraer;
	}
}
