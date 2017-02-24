using UnityEngine;
using System.Collections;

public class QKill : MonoBehaviour {
	
	public GameObject deathParticle;
	public CharController player;
	public GameObject bossTrig;
	public Transform bossTrigLocation;
	private ProjectileController bullet;
	
	
	void Start(){
		player = FindObjectOfType<CharController>();
		bullet = FindObjectOfType<ProjectileController>();
		
		
	}
	
	// Use this for initialization
	
	void RespawnPlayer(){
		StartCoroutine("Reload");
		
	}
	void OnTriggerEnter2D(Collider2D other){		
		
		if (other.gameObject.tag == "Player"){ // check if it's the player, if you want
			
			bullet.enabled = false;
			
			Instantiate(bossTrig,bossTrigLocation.position,bossTrigLocation.rotation);
			ShootPlayerInRange.contact = false;
			bosstrigger.inTrigger = false;
			audio.Play ();
			RespawnPlayer();
			
			
			
		}
	}
	
	IEnumerator Reload(){
		
		player.enabled = false;
		player.renderer.enabled = false;
		Instantiate(bossTrig,bossTrigLocation.position,bossTrigLocation.rotation);
		
		Instantiate(deathParticle, player.transform.position, player.transform.rotation);
		
		yield return new WaitForSeconds(0.2f);

		player.enabled = true;
		player.renderer.enabled = true;
		
		Application.LoadLevel(Application.loadedLevel);
		
		
	}
}