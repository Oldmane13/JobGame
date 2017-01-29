using UnityEngine;
using System.Collections;

public class SpringJump : MonoBehaviour {
	
	public float boing;
	private Rigidbody2D myRigid;
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other){
		
		if(other.gameObject.tag == "Player"){
			myRigid = other.GetComponent<CharController>().rigidbody2D;
			other.GetComponent<CharController>().rigidbody2D.velocity = new Vector2(myRigid.velocity.x,boing);
			audio.Play ();
		}
	}
}