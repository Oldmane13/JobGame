using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	public bool inTrigger;
	public GameObject trampSpawn;
	public Transform spawnPoint;
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player"){
			audio.Play ();
			inTrigger = true;
		
			
		}
	}
	
	void OnTriggerExit2DS(Collider2D other)
	{
		inTrigger = false;
	}
	
	void Update()
	{
		if (inTrigger)
		{
			
			if (Input.GetKeyDown(KeyCode.E))
			{
				
				Door.doorKey = true;
				
				Instantiate (trampSpawn, spawnPoint.position, spawnPoint.rotation);
				Destroy(this.gameObject);
			}
		}
	}
	
	
	void OnGUI()
	{
		if (inTrigger)
		{
			GUI.Box(new Rect(0, 60, 500, 25), "You found the key to the door! Press E to pick it up!");
		}
	}
}
