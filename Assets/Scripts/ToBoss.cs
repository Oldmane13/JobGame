using UnityEngine;
using System.Collections;

public class ToBoss : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other){
		
		if(other.gameObject.tag == "Player"){
			Application.LoadLevel("FinalLoadingScreen");
		}
	}
}