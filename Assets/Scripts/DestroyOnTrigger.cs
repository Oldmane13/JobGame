

using UnityEngine;
using System.Collections;

public class DestroyOnTrigger : MonoBehaviour
{
	Animator anim;
	public float bounce;
	public Rigidbody2D myrigid;
	public GameObject deathParticle;
	// Use this for initialization
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if(other.gameObject.tag == "Player"){
			audio.Play ();	
			anim = GetComponent<Animator>();
			anim.SetBool ("dead", true);
			
			myrigid = other.GetComponent<CharController>().rigidbody2D;
			other.GetComponent<CharController>().rigidbody2D.velocity = new Vector2(myrigid.velocity.x,bounce);
			
			Instantiate(deathParticle, transform.position, transform.rotation);
			Destroy(this.transform.parent.gameObject);
			Destroy(gameObject);
			
		}
		
	}
	
}