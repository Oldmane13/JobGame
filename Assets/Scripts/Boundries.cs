using UnityEngine;
using System.Collections;

public class Boundries : MonoBehaviour {
	
	public GameObject note;
	public GameObject panel;
	public GameObject image;
	public bool inText;
	
	void Start () {
		note.SetActive(false);
		panel.SetActive(false);
		image.SetActive(false);		
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
		if(other.gameObject.tag == "Player"){
			image.SetActive(true);
			note.SetActive(true);
			panel.SetActive(true);	
		}
	}
	
	void OnTriggerExit2D (Collider2D other){		
		if(other.gameObject.tag == "Player"){		
			note.SetActive(false);
			image.SetActive(false);
			panel.SetActive(false);
			Destroy(gameObject);
		}
	}	
}

