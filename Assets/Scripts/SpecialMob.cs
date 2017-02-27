using UnityEngine;
using System.Collections;

public class SpecialMob : MonoBehaviour {

	//Animator anim;
	public float bounce;
	public Rigidbody2D myrigid;
	public GameObject deathParticle;
	public EnemyControl mob;
	
	public GameObject note;
	public GameObject text1;
	public GameObject text2;
	public GameObject imag1;
	public GameObject imag2;
	
	// Use this for initialization
	
	void Start(){
		note.SetActive(false);
		text1.SetActive(false);
		text2.SetActive(false);
		imag1.SetActive(false);
		imag2.SetActive(false);
		
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
			StartCoroutine("WaitAndDisplay");
			
		}
		
	}
	IEnumerator WaitAndDisplay(){
		note.SetActive(true);
		text1.SetActive(true);
		text2.SetActive(true);
		imag1.SetActive(true);
		imag2.SetActive(true);
		
		Instantiate(deathParticle, transform.position, transform.rotation);
		this.transform.position = new Vector2(3,2);
		this.enabled = false;
		//mob.enabled = false;
		this.transform.parent.renderer.enabled = false;
		
		//mob.renderer.enabled =false;
		
		yield return new WaitForSeconds(2f);
		note.SetActive(false);
		text1.SetActive(false);
		text2.SetActive(false);
		imag1.SetActive(false);
		imag2.SetActive(false);
		Destroy(this.transform.parent.gameObject);
		Destroy(gameObject);
		
	}
	
}