using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MockCamera : MonoBehaviour {

	public Vector3 speed;
	public float wait = 3;

	private Vector3 _speed;

	public Text countDownWidget;

	// Use this for initialization
	void Start () {
		StartCoroutine(_Start());
	}

	IEnumerator _Start() {
		while(wait > 0) {
			countDownWidget.text = wait.ToString();
			yield return new WaitForSeconds(1);
			wait--;
		}
		countDownWidget.text = "Go";
		_speed = speed;
		yield return new WaitForSeconds(1);
		countDownWidget.transform.parent.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += _speed * Time.deltaTime;
	}
}
