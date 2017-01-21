using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickExplode : MonoBehaviour {
	public  Transform PosicionDeLaBola;
	public Rigidbody2D RigBody;
	public float MultiplicadorDeFuerza;
	public float MagnitudDeExplosion;
	public float TiempoSeleccionado;
	public float MaximoTiempoDeSeleccion;

	// Use this for initialization
	void Start () {
		PosicionDeLaBola = GetComponent<Transform>();
		RigBody = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Fire1")){
			activarTiempoDeCargaDeOnda ();
		}
		if (Input.GetButtonUp("Fire1")) {
			desplegarOnda ();
			}
	}

	public void desplegarOnda(){
		calcularMagnitudDeExplosion();
		Vector2 VectorDeClickHaObjeto =PosicionDeLaBola.position-Camera.main.ScreenToWorldPoint(Input.mousePosition);
		RigBody.AddForce ((MagnitudDeExplosion/VectorDeClickHaObjeto.magnitude)*VectorDeClickHaObjeto);
		TiempoSeleccionado = 0f;
	}

	public void activarTiempoDeCargaDeOnda(){
		TiempoSeleccionado += Time.deltaTime;
	}

	public void calcularMagnitudDeExplosion(){
		if (TiempoSeleccionado <= MaximoTiempoDeSeleccion) {
			float FraccionDeFuezaAlcanzada = (TiempoSeleccionado / MaximoTiempoDeSeleccion);
			print (FraccionDeFuezaAlcanzada);
			MagnitudDeExplosion = MultiplicadorDeFuerza * FraccionDeFuezaAlcanzada;
		} else {
			MagnitudDeExplosion = MultiplicadorDeFuerza;
		}
	}

	 void OnTriggerEnter2D(Collider2D ColliderConElQueColisiono){
		string TagDelCollider = ColliderConElQueColisiono.tag;
		if(TagDelCollider=="ObstaculoAsesino"){
			print ("GameOver");
		}
	}
}
