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

	private bool isAlive;

	// Use this for initialization
	void Start () {
		PosicionDeLaBola = GetComponent<Transform>();
		RigBody = GetComponent<Rigidbody2D> ();
		isAlive = true;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Fire1")){
			activarTiempoDeCargaDeOnda ();
		}
		if (Input.GetButtonUp("Fire1")) {
			desplegarOnda ();
		}
		if (Input.GetButtonDown("Fire1")) {
			Vector2 VectorDeBolaHaPuntero =PosicionDeLaBola.position-Camera.main.ScreenToWorldPoint(Input.mousePosition);
			print (VectorDeBolaHaPuntero);
			RigBody.AddForce ((MultiplicadorDeFuerza/VectorDeBolaHaPuntero.magnitude)*VectorDeBolaHaPuntero);
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
			if(isAlive) StartCoroutine(NivelPerdido());
		}
	}

	void OnBecameInvisible(){
		if(isAlive) StartCoroutine(NivelPerdido());
	}

	public IEnumerator NivelPerdido(){
		isAlive = false;
		yield return new WaitForSeconds(2);
		Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
	}
}
