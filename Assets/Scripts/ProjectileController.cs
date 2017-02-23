using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {

	public float speed;
	private float angle;
	public CharController player;
	public static Animator anim;

	

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		player = FindObjectOfType<CharController>();
		angle = Random.Range(-1,1);
		
		
		if(player.transform.position.x < transform.position.x)
			speed = -speed;
	}
	
	// Update is called once per frame
	void Update () {
	
		rigidbody2D.velocity = new Vector2(speed, angle);	
	}
	
	void OnTriggerEnter2D(Collider2D other){
		
		//if(other.tag == "Player")
			//Destroy (other.gameObject);
		if(other.tag == "Barrier")	
			Destroy(gameObject);
	}
}
