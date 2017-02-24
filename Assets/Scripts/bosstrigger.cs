using UnityEngine;
using System.Collections;



public class bosstrigger : MonoBehaviour {
	public static bool inTrigger;
	public CharController player;
	public ShootPlayerInRange boss;
	public GameObject text1;
	
	void Start(){
		boss = FindObjectOfType<ShootPlayerInRange>();
		player = FindObjectOfType<CharController>();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player"){
			ShootPlayerInRange.anim.SetBool("Contact", true);
			player.enabled = false;
			boss.enabled = false;
			text1.SetActive(true);
			CharController.anim.SetFloat("vSpeed",0f);
			CharController.anim.SetFloat("Speed",0f);
			
			
			
		}
	}
	
	void Update() {
	
	if (inTrigger){
	

			player.enabled = true;
			boss.enabled = true;
			text1.SetActive(false);
			ShootPlayerInRange.contact = true;
			
			Destroy(gameObject);
			
			
		
	}
	
	
	}
	
	// Update is called once per frame
	
}
