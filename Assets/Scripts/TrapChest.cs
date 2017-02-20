using UnityEngine;
using System.Collections;

public class TrapChest : MonoBehaviour {

	public GameObject textTrap;
	public GameObject panelTrap;
	public GameObject trampSpawn;
	//public GameObject enemy1;
	//public GameObject enemy2;
	private bool inTrigger;
	private bool chestOpened;
	private CharController Character;
	public Transform spawnPoint;
	//public Transform enemySpawn1;
	//public Transform enemySpawn2;
	Animator anim;
	public Transform target;

	public GameObject monster;
	

	
	void Start(){
		anim = GetComponent<Animator>();
		Character = FindObjectOfType<CharController>();
		panelTrap.SetActive(false);
		textTrap.SetActive(false);

	}
	
	void OnTriggerEnter2D (Collider2D other) {
		
		if (other.gameObject.tag == "Player"){
			inTrigger = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (inTrigger)
		{
			if (Input.GetKeyDown(KeyCode.E)){
				
				anim.SetBool("Contact", true);
				//audio.Play();
				chestOpened = true;
				textTrap.SetActive(true);
				panelTrap.SetActive(true);
				Character.enabled = false;
			}
			if (chestOpened){
				
				if (Input.GetKeyDown(KeyCode.Space))
				{
					Character.enabled = true;
					inTrigger = false;
					Instantiate (monster, transform.position, transform.rotation);
					Destroy(gameObject);
					
					textTrap.SetActive(false);
					panelTrap.SetActive(false);
					Instantiate (trampSpawn, spawnPoint.position, spawnPoint.rotation);
					//Instantiate (enemy1, enemySpawn1.position, enemySpawn1.rotation);
					//Instantiate (enemy2, enemySpawn2.position, enemySpawn2.rotation);
					//Character.enabled = true;
					//Destroy(this.gameObject);
					
				}
			}
		}
	}
	void OnGUI()
	{
		if (inTrigger)
		{
			GUI.Box(new Rect(0, 60, 200, 25), "Press E to open chest");
		}
	}
}
