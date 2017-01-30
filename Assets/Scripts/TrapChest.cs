using UnityEngine;
using System.Collections;

public class TrapChest : MonoBehaviour {

	public GameObject textTrap;
	public GameObject panelTrap;
	public GameObject initialText;
	public GameObject trampSpawn;
	public GameObject enemy1;
	public GameObject enemy2;
	private bool inTrigger;
	private bool chestOpened;
	private CharController Character;
	public Transform spawnPoint;
	public Transform enemySpawn1;
	public Transform enemySpawn2;
	GameObject player = GameObject.Find("Character");
	
	
	void Start(){
		GameObject player = GameObject.Find("Character");
		initialText.SetActive(false);
		panelTrap.SetActive(false);
		textTrap.SetActive(false);
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		
		if (other.gameObject.tag == "Player"){
			inTrigger = true;
			initialText.SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (inTrigger)
		{
			if (Input.GetKeyDown(KeyCode.E)){
				
				GameObject player = GameObject.Find("Character");
				CharController CharController = player.GetComponent<CharController>();
				
				chestOpened = true;
				initialText.SetActive(false);
				textTrap.SetActive(true);
				panelTrap.SetActive(true);
				CharController.enabled = false;
			}
			if (chestOpened){
				
				if (Input.GetKeyDown(KeyCode.Space))
				{
					GameObject player = GameObject.Find("Character");
					
					CharController CharController = player.GetComponent<CharController>();
					CharController.enabled = true;
					textTrap.SetActive(false);
					panelTrap.SetActive(false);
					Instantiate (trampSpawn, spawnPoint.position, spawnPoint.rotation);
					Instantiate (enemy1, enemySpawn1.position, enemySpawn1.rotation);
					Instantiate (enemy2, enemySpawn2.position, enemySpawn2.rotation);
					
					Destroy(this.gameObject);
				}
			}
		}
	}
}
