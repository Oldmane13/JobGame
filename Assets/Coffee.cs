using UnityEngine;
using System.Collections;

public class Coffee : MonoBehaviour {
	
	GameObject player;
	public GameObject note;
	public GameObject panel;

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.Find("Character");
		CharController CharController = player.GetComponent<CharController>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	
	}
	
	void OnTriggerEnter2D(Collider2D other){
		GameObject player = GameObject.Find("Character");
		CharController CharController = player.GetComponent<CharController>();
		if (other.gameObject.tag == "Player"){
			note.SetActive(true);
			panel.SetActive(true);	
		if (Input.GetKey(KeyCode.Return)){
				note.SetActive(false);
				panel.SetActive(false);	
		}
		
		}
	
	}
	
	//IEnumerator Congrats(){
	
	//}
}
