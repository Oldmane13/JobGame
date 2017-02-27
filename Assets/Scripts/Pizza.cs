using UnityEngine;
using System.Collections;

public class Pizza : MonoBehaviour {

	private CharController player;
	public GameObject note;
	public GameObject panel;
	public float waitTime;
	private bool inTrigger;
	public EnemyControl mob;
	public GameObject wall;
	public Transform wallPos;
	
	// Use this for initialization
	void Start () {
		note.SetActive(false);
		panel.SetActive(false);
		player = FindObjectOfType<CharController>();
		mob = FindObjectOfType<EnemyControl>();
		
	}
	
	void Update () {
		if (inTrigger)
		{
			CatchPizza ();
			if (Input.GetKeyDown(KeyCode.Space)){				
				player.enabled = true;
				note.SetActive(false);
				panel.SetActive(false);	
				Destroy(gameObject);
			}
		}
	}
	
	void CatchPizza(){

		
		note.SetActive(true);
		panel.SetActive(true);
	}
	
	void OnTriggerEnter2D(Collider2D other){
		
		if (other.gameObject.tag == "Player"){
			//mob.enabled = false;
			Instantiate(wall, wallPos.position, wallPos.rotation);
			inTrigger = true;
			audio.Play();
			gameObject.renderer.enabled = false;
			player.enabled = false;
			CharController.anim.SetFloat("vSpeed",0f);
			CharController.anim.SetFloat("Speed",0f);
			CatchPizza();
				
		}
		
		
	}
	
}