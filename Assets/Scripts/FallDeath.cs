using UnityEngine;
using System.Collections;

public class FallDeath : MonoBehaviour {
	
	public GameObject Respawn;
	CharController player;
	public GameObject deathParticle;

	
	void Start(){
		player = FindObjectOfType<CharController>();

		
	}
	// Use this for initialization
	
	void RespawnPlayer(){
		StartCoroutine("Reload");
		
	}
	void OnTriggerEnter2D(Collider2D other){
		
		
		if (other.gameObject.tag == "Player"){ // check if it's the player, if you want

			audio.Play ();
			RespawnPlayer();
			
			
			
		}
	}
	
	IEnumerator Reload(){
		
		player.enabled = false;
		player.renderer.enabled = false;
		
		Respawn = GameObject.FindGameObjectWithTag("Respawn");
		Instantiate(deathParticle, player.transform.position, player.transform.rotation);
		
		yield return new WaitForSeconds(0.2f);
	
		player.enabled = true;
		player.renderer.enabled = true;
		player.transform.position = Respawn.transform.position;
		Application.LoadLevel(Application.loadedLevel);
		
		
	}
}