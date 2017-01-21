using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ClickExplode : MonoBehaviour {
	public  Transform PosicionDeLaBola;
	public Rigidbody2D RigBody;
	public float MultiplicadorDeFuerza;
	public float MagnitudDeExplosion;
	public float TiempoSeleccionado;
	public float MaximoTiempoDeSeleccion;
	public GameObject OndaInicial;
	public bool EnPausa;
	public Canvas CanvasDelMenu;

	// Use this for initialization
	void Start () {
		PosicionDeLaBola = GetComponent<Transform>();
		RigBody = GetComponent<Rigidbody2D> ();
		EnPausa = false;
		Time.timeScale = 1;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Fire1")){
			if(!EnPausa){
				activarTiempoDeCargaDeOnda ();	
			}
		}
		if (Input.GetButtonUp("Fire1")) {
			if(!EnPausa){
				desplegarOnda ();
			}
		}

		if(Input.GetKeyDown(KeyCode.Escape)){
			if(EnPausa){
				Time.timeScale = 1;
				DesactivarMenu ();
			}else{
				ActivarMenu ();
				Time.timeScale = 0;
			}
			EnPausa = !EnPausa;
		}
	}

	public void desplegarOnda(){
		calcularMagnitudDeExplosion();
		Vector2 PosicionDelMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		iniciarOnda (PosicionDelMouse);
		TiempoSeleccionado = 0f;
	}

	public void iniciarOnda(Vector2 PosicionDeGeneracion){
		GameObject OndaGenerada = Instantiate (OndaInicial);
		OndaGenerada.transform.position = PosicionDeGeneracion;
		Onda ScriptHonda = OndaGenerada.GetComponent<Onda> ();
		ScriptHonda.setRadioDeOnda (2.5f);
	    ScriptHonda.SetFuerzaDeOnda (MagnitudDeExplosion);
		ScriptHonda.setAtraer (false);
		ScriptHonda.DestruirOnda ();
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

	void OnCollisionEnter2D(Collision2D ObjetoQueColiciono){
		string TagDelCollider = ObjetoQueColiciono.gameObject.tag;
		if(TagDelCollider=="ObstaculoAsesino"){
			print ("GameOver");
			NivelPerdido ();
		}
	}

	void OnBecameInvisible(){
		NivelPerdido ();
	}

	public void NivelPerdido(){
		string IndiceEscenaHaCargar = "PruebaEffectos";
		SceneManager.LoadScene (IndiceEscenaHaCargar);
	}

	public void ActivarMenu(){
		CanvasDelMenu.gameObject.SetActive(true);
	}

	public void DesactivarMenu(){
		CanvasDelMenu.gameObject.SetActive(false);
	}
}
