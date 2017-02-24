using UnityEngine;
using System.Collections;

public class KillText : MonoBehaviour {

	public float bounce;
	public Rigidbody2D myrigid;
	public GameObject deathParticle;
	public ProjectileController bullet;
	// Use this for initialization
	void Start(){
		bullet = FindObjectOfType<ProjectileController>();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if(other.gameObject.tag == "Player"){
			audio.Play ();		
			myrigid = other.GetComponent<CharController>().rigidbody2D;
			other.GetComponent<CharController>().rigidbody2D.velocity = new Vector2(myrigid.velocity.x,bounce);
			StartCoroutine("WaitABit");
		}		
	}
	
	IEnumerator WaitABit(){
		
		Instantiate(deathParticle, transform.position, transform.rotation);
		this.enabled = false;
		bullet.enabled = false;
		this.transform.parent.renderer.enabled = false;	
		
		yield return new WaitForSeconds(0.5f);
		
		Destroy(this.transform.parent.gameObject);
		Destroy(gameObject);
		
	}
}
