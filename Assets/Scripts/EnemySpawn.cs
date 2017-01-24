using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

public GameObject spawnable;
public Transform spawnPoint;

	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
	
		if (other.gameObject.tag == "Camera"){	
			Instantiate (spawnable, spawnPoint.position, spawnPoint.rotation);
			Destroy(gameObject);
		}
	}
}
