using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	public PlayerDeath KillPlayer;

	// Use this for initialization
	void Start () {
	KillPlayer = FindObjectOfType<PlayerDeath>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player"){
			//KillPlayer.Respawn = gameObject;
		}
	}
}
