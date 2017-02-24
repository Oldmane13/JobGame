using UnityEngine;
using System.Collections;

public class MobText : MonoBehaviour {

	public GameObject text;
	public GameObject panel;
	public GameObject trampSpawn;
	public static bool inTrigger;
	private CharController Character;
	public Transform spawnPoint;
	public Arrow arrow;

	
	void Start(){
		arrow = FindObjectOfType<Arrow>();
		Character = FindObjectOfType<CharController>();
		panel.SetActive(false);
		text.SetActive(false);
	}
	
	void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.tag == "Player"){
			//inTrigger = true;
			text.SetActive(true);
			panel.SetActive(true);
			Character.enabled = false;
			CharController.anim.SetFloat("vSpeed",0f);
			CharController.anim.SetFloat("Speed",0f);	
			}
		}
	
	// Update is called once per frame
	void Update () {
		if (inTrigger)
		{
			//if (Input.GetKeyDown(KeyCode.Space))
			//{
				Character.enabled = true;
				text.SetActive(false);
				panel.SetActive(false);
				Instantiate (trampSpawn, spawnPoint.position, spawnPoint.rotation);
				Destroy (arrow.gameObject);
				Destroy(this.gameObject);
			//}
		}
	
	}
}
