using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {
	public GameObject Respawn;
	GameObject player;
	public GameObject deathParticle;
	
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other){
		
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		
		if (other.gameObject.tag == "Player"){ // check if it's the player, if you want
			
			Respawn = GameObject.FindGameObjectWithTag("Respawn");
			Instantiate(deathParticle, player.transform.position, player.transform.rotation);
			
			audio.Play ();

			player.transform.position = Respawn.transform.position;
			Instantiate(deathParticle, player.transform.position, player.transform.rotation); 
			
		}
	}
}