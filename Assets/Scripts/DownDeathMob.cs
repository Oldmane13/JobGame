using UnityEngine;
using System.Collections;

public class DownDeathMob : MonoBehaviour {
	
	public GameObject deathParticle;

	
	void OnTriggerEnter2D(Collider2D other)
	{
			
		if(other.gameObject.tag == "Finish"){
			
			//audio.Play ();				
			Instantiate(deathParticle, transform.position, transform.rotation);
			this.enabled = false;
			//mob.enabled = false;
			this.transform.parent.renderer.enabled = false;
			Destroy(this.transform.parent.gameObject);
			Destroy(gameObject);
			
		}
		
	}
}
