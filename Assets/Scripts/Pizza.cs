using UnityEngine;
using System.Collections;

public class Pizza : MonoBehaviour {

	private CharController player;
	public GameObject note;
	public GameObject panel;
	public float waitTime;
	private bool inTrigger;
	
	// Use this for initialization
	void Start () {
		note.SetActive(false);
		panel.SetActive(false);
		player = FindObjectOfType<CharController>();
		
	}
	
	void Update () {
		if (inTrigger)
		{
			CatchPizza ();
			if (Input.GetKeyDown(KeyCode.Space)){				
				player.enabled = true;
				note.SetActive(false);
				panel.SetActive(false);	
				Destroy(gameObject);
			}
		}
	}
	
	void CatchPizza(){

		
		note.SetActive(true);
		panel.SetActive(true);
	}
	
	void OnTriggerEnter2D(Collider2D other){
		
		if (other.gameObject.tag == "Player"){
			inTrigger = true;
			audio.Play();
			gameObject.renderer.enabled = false;
			player.enabled = false;
			CatchPizza();
				
		}
		
		
	}
	
}