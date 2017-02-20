using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	public bool inTrigger;
	public GameObject trampSpawn;
	public Transform spawnPoint;
	Animator anim;
	
	void Start(){
		
		anim = GetComponent<Animator>();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player"){
			
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
				
				lel ();
				Instantiate (trampSpawn, spawnPoint.position, spawnPoint.rotation);

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
	IEnumerator Sound()
	{
		anim.SetBool("KeyDed", true);
		audio.Play ();
		yield return new WaitForSeconds(1.2f); // wait for two seconds.
		Destroy(gameObject);
	}
	
	void lel(){
		StartCoroutine("Sound");
	}
}
