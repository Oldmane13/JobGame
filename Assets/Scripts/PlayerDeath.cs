﻿using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {
	public GameObject Respawn;
	GameObject player;
	public GameObject deathParticle;
	public CharController Character;
	private float gravityStore;
	GameObject thePlayer = GameObject.Find("Character");
	
	void Start(){
		GameObject player = GameObject.Find("Character");
		GameObject thePlayer = GameObject.Find("Character");
		CharController CharController = thePlayer.GetComponent<CharController>();
		
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
		
		GameObject player = GameObject.Find("Character");
		//player.renderer.enabled = false;
		CharController CharController = player.GetComponent<CharController>();
		CharController.enabled = false;
		CharController.renderer.enabled = false;
		Respawn = GameObject.FindGameObjectWithTag("Respawn");
		Instantiate(deathParticle, player.transform.position, player.transform.rotation);
		
		yield return new WaitForSeconds(0.5f);
		//player.renderer.enabled = true;
		CharController.enabled = true;
		CharController.renderer.enabled = true;
		player.transform.position = Respawn.transform.position;
		
		
	}
}