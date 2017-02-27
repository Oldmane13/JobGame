

using UnityEngine;
using System.Collections;

public class DestroyOnTrigger : MonoBehaviour
{
	//Animator anim;
	public float bounce;
	public Rigidbody2D myrigid;
	public GameObject deathParticle;
	public EnemyControl mob;
	// Use this for initialization
	
	void Start(){
	mob = FindObjectOfType<EnemyControl>();
	//anim = GetComponent<Animator>();
	}
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Finish"){
			
			//audio.Play ();				
			myrigid = other.GetComponent<CharController>().rigidbody2D;
			other.GetComponent<CharController>().rigidbody2D.velocity = new Vector2(myrigid.velocity.x,bounce);
			
			Instantiate(deathParticle, transform.position, transform.rotation);
			StartCoroutine("WaitABit");
			
		}
		
	}
	IEnumerator WaitABit(){
		
		Instantiate(deathParticle, transform.position, transform.rotation);
		this.enabled = false;
		//mob.enabled = false;
		this.transform.parent.renderer.enabled = false;
		
		//mob.renderer.enabled =false;
		
		yield return new WaitForSeconds(0.5f);
		Destroy(this.transform.parent.gameObject);
		Destroy(gameObject);
	
	}
	
}