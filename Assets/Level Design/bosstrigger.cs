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
		
			player.enabled = false;
			boss.enabled = false;
			text1.SetActive(true);
			
			
			
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
