using UnityEngine;
using System.Collections;

public class Coffee : MonoBehaviour {
	
	GameObject player;
	public GameObject note;
	public GameObject panel;

	// Use this for initialization
	void Start () {
		note.SetActive(false);
		panel.SetActive(false);
		GameObject player = GameObject.Find("Character");
		CharController CharController = player.GetComponent<CharController>();
	
	}
	
	void Smth(){
		
		StartCoroutine("Congrats");
	}
	
	void OnTriggerEnter2D(Collider2D other){
		GameObject player = GameObject.Find("Character");
		CharController CharController = player.GetComponent<CharController>();
		if (other.gameObject.tag == "Player"){
			gameObject.renderer.enabled = false;
			Smth();
			audio.Play();	
		}
	
		
	}
	
	
	
	IEnumerator Congrats(){
		
		note.SetActive(true);
		panel.SetActive(true);
		
		yield return new WaitForSeconds(5f);

		note.SetActive(false);
		panel.SetActive(false);	
		Destroy(gameObject);
		Application.LoadLevel("LoadingScreen2");
	}
	
}
	
