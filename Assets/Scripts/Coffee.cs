using UnityEngine;
using System.Collections;

public class Coffee : MonoBehaviour {
	
	private CharController player;
	public GameObject note;
	public GameObject panel;
	private bool inTrigger;

	// Use this for initialization
	void Start () {
		note.SetActive(false);
		panel.SetActive(false);
		player = FindObjectOfType<CharController>();
	
	}
	
	void Update(){
		if (inTrigger)
		{
			Smth ();
			if (Input.GetKeyDown(KeyCode.Space)){				
				player.enabled = true;
				note.SetActive(false);
				panel.SetActive(false);	
				Destroy(gameObject);
				Application.LoadLevel("LoadingScreen2");
			}
		}
	}
	
	void Smth(){
		
		note.SetActive(true);
		panel.SetActive(true);
	}
	
	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Player"){
			inTrigger = true;
			audio.Play();
			gameObject.renderer.enabled = false;
			player.enabled = false;
			Smth ();
	
		
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
	
