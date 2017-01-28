using UnityEngine;
using System.Collections;

public class WallBounce : MonoBehaviour {

	public Rigidbody2D myrigid;
	public float boing;
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other){			
		
		if(other.gameObject.tag == "Player"){								
			myrigid = other.GetComponent<CharController>().rigidbody2D;
			other.GetComponent<CharController>().rigidbody2D.velocity = new Vector3(boing,myrigid.velocity.y,boing);			
		}
	}
}
