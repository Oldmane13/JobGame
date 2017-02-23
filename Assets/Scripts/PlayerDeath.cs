using UnityEngine;
using System.Collections;


public class PlayerDeath : MonoBehaviour {
	
	//public GameObject Respawn;
	CharController player;
	public GameObject deathParticle;
	EnemyControl mob;
	
	void Start(){
		player = FindObjectOfType<CharController>();
		mob = FindObjectOfType<EnemyControl>();
		
	}
	// Use this for initialization
	
	void RespawnPlayer(){
		StartCoroutine("Reload");
		
	}
	void OnTriggerEnter2D(Collider2D other){
		
		
		if (other.gameObject.tag == "Player"){ // check if it's the player, if you want
			mob.enabled = false;
			audio.Play ();
			RespawnPlayer();
			
			
			
		}
	}
	
	IEnumerator Reload(){
		
		
		player.renderer.enabled = false;
		player.enabled = false;
		//Respawn = GameObject.FindGameObjectWithTag("Respawn");
		Instantiate(deathParticle, player.transform.position, player.transform.rotation);
		
		yield return new WaitForSeconds(0.5f);
		//player.renderer.enabled = true;
		player.enabled = true;
		player.renderer.enabled = true;
		//player.transform.position = Respawn.transform.position;
		Application.LoadLevel(Application.loadedLevel);
		
		
	}
}