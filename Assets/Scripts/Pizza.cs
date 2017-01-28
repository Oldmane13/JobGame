using UnityEngine;
using System.Collections;

public class Pizza : MonoBehaviour {

	GameObject player;
	public GameObject note;
	public GameObject panel;
	public float waitTime;
	
	// Use this for initialization
	void Start () {
		note.SetActive(false);
		panel.SetActive(false);
		GameObject player = GameObject.Find("Character");
		CharController CharController = player.GetComponent<CharController>();
		
	}
	
	void CatchPizza(){
		
		StartCoroutine("End");
	}
	
	void OnTriggerEnter2D(Collider2D other){
		GameObject player = GameObject.Find("Character");
		CharController CharController = player.GetComponent<CharController>();
		if (other.gameObject.tag == "Player"){
			gameObject.renderer.enabled = false;
			CatchPizza();
			audio.Play();	
		}
		
		
	}
	
	
	
	IEnumerator End(){
		
		note.SetActive(true);
		panel.SetActive(true);
		
		yield return new WaitForSeconds(waitTime);
		
		note.SetActive(false);
		panel.SetActive(false);	
		Destroy(gameObject);
	}
	
}