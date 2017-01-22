using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sierra : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D ObjetoQueColiciono){
		string TagDelCollider = ObjetoQueColiciono.gameObject.tag;
		if (TagDelCollider == "Player") {
			ObjetoQueColiciono.gameObject.SendMessage("Epilepsia", SendMessageOptions.DontRequireReceiver);
		}
	}
}
