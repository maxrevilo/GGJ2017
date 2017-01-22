using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
    public Rigidbody2D Rigid; 
	public BoxCollider2D ColliderDeSobrePaso;

	public Rigidbody2D RigidConejo;

	bool acelerated = false;
	public float wait = 3;
	public Text countDownWidget;
	public RectTransform winPanel;

	public float velocidad = 1f;

	public string nextScene = "Creditos";

    void Start()
    {
		if(RigidConejo == null) throw new Exception("RigidConejo is not set");
		if(countDownWidget == null) throw new Exception("countDownWidget is not set");
		if(winPanel == null) throw new Exception("winPanel is not set");
        Rigid = gameObject.GetComponent<Rigidbody2D>();
		ColliderDeSobrePaso = gameObject.GetComponent<BoxCollider2D> ();
		acelerated = false;

		StartCoroutine(_Start());
	}

	IEnumerator _Start() {
		while(wait > 0) {
			countDownWidget.text = wait.ToString();
			yield return new WaitForSeconds(1);
			wait--;
		}
		countDownWidget.text = "Go";

		Vector2 Velocidad = new Vector2(velocidad,0f);
        Rigid.velocity = Velocidad;

		yield return new WaitForSeconds(1);
		countDownWidget.transform.parent.gameObject.SetActive(false);
	}

    void FixedUpdate()
    {
      if(acelerated) {
		  Vector3 position = transform.position;
		  position.x += 5 * RigidConejo.velocity.x * Time.fixedDeltaTime;
		  transform.position = position;
	  }
    }

	public void OnTriggerEnter2D(Collider2D ColliderObjetivo ){
		if (ColliderObjetivo.tag == "Player") {
			acelerated = true;
		}
	}

	public void OnTriggerExit2D(Collider2D ColliderObjetivo ){
		if(ColliderObjetivo.tag=="Player"){
			acelerated = false;	
		}
	}

	public void Win() {
		winPanel.gameObject.SetActive(false);
		StartCoroutine(_Win());
	}
	IEnumerator _Win() {
		acelerated = false;	
        Rigid.velocity = new Vector2(velocidad / 3f, 0f);;
		yield return new WaitForSeconds(1.5f);
		winPanel.gameObject.SetActive(true);
		yield return new WaitForSeconds(1.5f);
		winPanel.gameObject.SetActive(false);
		yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextScene);
	}
}
